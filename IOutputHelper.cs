using System;

namespace EtabsAPI
{
    interface IOutputHelper
    {
        void StartMessage();
        void ErrorMessage();
        void NoErrorMessage();
    }
}