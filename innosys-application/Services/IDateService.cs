using System;

namespace innosys_application.Services
{
    public interface IDateService
    {
        /*
         string format : yyyyMMddTHHmm
         */
        DateTime StringToDateTime(string date);
    }
}
