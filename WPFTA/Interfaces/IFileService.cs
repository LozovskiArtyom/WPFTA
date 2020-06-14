using System;
using System.Collections.Generic;
using System.Text;

namespace WPFTA
{
    public interface IFileService
    {
        List<UserDay> Open(string filename);
        void Save(string filename, List<UserDay> phonesList);
    }
}
