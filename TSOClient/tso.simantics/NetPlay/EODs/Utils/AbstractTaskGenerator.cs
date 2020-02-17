using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSO.SimAntics.NetPlay.EODs.Utils
{
    public class AbstractTaskGenerator<T> where T : ITaskSet
    {
        private ITaskSet Source;
        private static Random TaskRandom = new Random(); // the less of these created the better -- use one for all task generators
        public AbstractTaskGenerator(ITaskSet taskPool)
        {
            RegisterTaskSet(taskPool);
        }

        public void RegisterTaskSet(ITaskSet set)
        {
            Source = set;
        }

        public FSOAbstractTask GetRandom(string ignoreKey = null)
        {
            var task = Source.Tasks[TaskRandom.Next(0, Source.Tasks.Count - 1)];
            if (ignoreKey != null)
                while (true) { // try again until we don't match
                    if(task.Key == ignoreKey)
                        task = Source.Tasks[TaskRandom.Next(0, Source.Tasks.Count - 1)];
                    if (task.Key != ignoreKey)
                        break;
                }
            return task;
        }

        public FSOAbstractTask Get(string key)
        {
            return Source.Tasks.FirstOrDefault(x => x.Key == key);
        }
    }

    public interface ITaskSet
    {
        List<FSOAbstractTask> Tasks { get; set; }
    }

    public class FSOAbstractTask
    {
        public string Key { get; private set; }
        public int ActionsCompleted { get; private set; }
        public int TotalActions { get; set; }
        public bool Completed => ActionsCompleted >= TotalActions;

        public FSOAbstractTask(string key, int totalactions, int progression = 0)
        {
            Key = key;
            ActionsCompleted = progression;
            TotalActions = totalactions;
        }

        public void ActionCompleted(int step = 1)
        {
            ActionsCompleted+=step;
        }
    }    
}
