using FSO.SimAntics.NetPlay.EODs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSO.SimAntics.NetPlay.EODs.Handlers
{   
    public class VMEODPartyPlugin : VMEODHandler
    {
        private readonly int LobbySeconds = 75; // plenty of time for roomies to join EOD
        private readonly int EndScreenSeconds = 100; // plenty of time to see results of the party before disconnecting all hosts
        private readonly int GameplaySeconds = 60 * 20;
        
        private VMEODPartyState State;
        private Dictionary<VMEODClient, VMEODPartyPlayer> Hosts = new Dictionary<VMEODClient, VMEODPartyPlayer>(); // we want to ensure this never has more than the amount of lot owners/roomies

        private int ElapsedFrames = 0;
        private int TotalTime = 0; // the total amount of time the event has been active
        private int Timer = -1; // a situational timer
        private VMEODClient ControlClient;

        public VMEODPartyPlugin(VMEODServer server) : base(server)
        {
            PlaintextHandlers["close"] = P_Close;

            //TODO: SimAntics handlers
            //SimanticsHandlers[(short)VMEODPartyEvent.Wait] = S_RespondPhone;
        }

        public override void OnConnection(VMEODClient client)
        {
            // TODO: var param = client.Invoker.Thread.TempRegisters;
            if (client.Avatar != null)
            {
                //take tuning settings from object
                //TODO: Set tuning settings

                //are we already entered?
                if (Hosts.TryGetValue(client, out _))
                {
                    //after the lobby, the only way a player can join is if they were
                    //playing before.. handle anything specific to this here
                }
                else
                {
                    if (State == VMEODPartyState.Lobby)
                        Hosts.Add(client, new VMEODPartyPlayer());
                    else
                    {
                        Server.Disconnect(client); // you can't join in the middle!
                    }
                }                    
                client.Send("party_show", "");                               
                PlayerRosterUpdate();            
            }
            else
            {
                //we're the ~pizza party~ controller!
                ControlClient = client;
            }
        }
        private void P_Close(string evt, string body, VMEODClient client)
        {
            //handle closing here
        }

        public override void OnDisconnection(VMEODClient client)
        {
            base.OnDisconnection(client);
        }

        private void DisconnectAllPlayers()
        {
            foreach (var player in Hosts.Keys)
                Server.Disconnect(player);
        }

        private void PlayerRosterUpdate()
        {
            
        }        

        public override void SelfResync()
        {
            //handle resync logic.. likely nothing needs to be done
            base.SelfResync();
        }

        private void SetTimer(int amount)
        {
            Timer = amount;
            ElapsedFrames = 0;
            SendTime();
        }

        /// <summary>
        /// Syncs the current timer with all players
        /// </summary>
        private void SendTime()
        {
            foreach (var player in Hosts.Keys)
                if (player != null) player.Send("party_time", Timer.ToString());
        }

        public override void Tick()
        {
            if (ControlClient == null)
                return; // we won't tick until our controller has arrived
            if (Timer >= 0)
            {
                if (++ElapsedFrames >= 30)
                {
                    ElapsedFrames = 0;
                    Timer--;
                    SendTime();
                }
            }
            switch (State)
            {
                case VMEODPartyState.Lobby:
                    foreach (var player in Hosts.Values)
                        ;// player.CleanedObjects = 0;
                    if (Timer <= 0)                    
                        EnterState(VMEODPartyState.Party_Active);                    
                    break;
                case VMEODPartyState.Party_Active:
                    if (Timer <= 0)
                        EnterState(VMEODPartyState.Party_Over);
                    break;
                case VMEODPartyState.Party_Over:
                    if (Timer <= 0)
                        DisconnectAllPlayers();  
                    break;
            }
            Timer++;
        }       

        private void EnterState(VMEODPartyState state)
        {
            State = state;
            foreach (var player in Hosts.Keys)
                if (player != null) player.Send("party_state", ((byte)State).ToString());
            switch (State)
            {
                case VMEODPartyState.Lobby:
                    SetTimer(LobbySeconds);
                    break;
                case VMEODPartyState.Party_Active:
                    SetTimer(GameplaySeconds);
                    break;
                case VMEODPartyState.Party_Over:
                    SetTimer(EndScreenSeconds);
                    break;
            }
        }
    }

    public enum VMEODPartyState : byte
    {
        Lobby, // allow roomies to opt in
        Party_Active, // the party is on
        Party_Over // the party is now over, show ending stats and allow guests to vacate the area
    }    

    public enum VMEODPartyDifficulty
    {
        Calm, 
        Lively,
        Intense,
        Raging
    }

    public enum VMEODPartyEvent
    {
        Wait, // waiting for party to start or enter rest period
        CreateGuests, // create guests for current difficulty level
        DifficultyUp, // increase the difficulty 1 level
        TaskCompleted, // a player has completed a task
        CreateCelebrity, // create a famous celebrity

        CelebrityLeaveBored, // celebrity leaves, not good enough cleanliness level
        CelebrityLeaveImpressed // celebrity leaves, host successful.. bonus payout
    }

    public enum VMEODPartyJob
    {
        Host, // hosting the event
        Guest_Regular, // attending the event with positive interaction
        Guest_Sabotage // attending the event with negative interaction
    }

    public class VMEODPartyPlayer
    {
        FSOAbstractTask[] Tasks;
    }
}
