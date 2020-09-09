using System;

namespace EtabsAPI
{
    interface IOutput
    {
        void StartMessage();
        void ErrorMessage();
        void NoErrorMessage();
    }
}