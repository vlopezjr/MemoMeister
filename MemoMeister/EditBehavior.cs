using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoMeister
{
    public enum EditBehavior
    {
        AutoSaveOnClose = 0,
        NoAutoSave = 1,
        PromptForSave = 2
    }

    internal enum Database
    {
        Production,
        Development
    }
}
