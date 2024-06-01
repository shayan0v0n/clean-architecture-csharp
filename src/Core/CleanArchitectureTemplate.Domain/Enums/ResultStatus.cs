using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureTemplate.Domain.Enums
{
    public enum ResultStatus
    {
        Success = 200,
        NoContent = 204,
        BadRequest = 400,
        Unauthorize = 401,
        WaitConfirmEmail = 402,
        NotFound = 404,
        TimeOut = 408,
        Conflict = 409,
        LimitExceeded = 429,
        Error = 500,
        ServiceUnAvailable = 503,
        LimitCountReserved = 450,
        LimitCountUnReservedSim = 451,
        LimitCountUnReservedCart = 452,
        NullSimcard = 455,
        Locked = 453,
        Duplicate = 403,
        NotValid = 405,
        NotLogin = 406,
        NotCompletedProfile = 407,
        WaitAcceptProfile = 408,
        ShabaNotValid = 411,
        UserDebtor = 410,
        NationalCodeDuplicate = 412,
        NotValidNationalCode = 413,
        NotFoundUser = 414,
        NotPossibleUpdatePrice = 415,

        #region
        //Products
        //NotValidReserve = 416,
        //SoldProducts = 417,
        //notPay = 418,
        //NotCompletePay = 419
        #endregion

    }
}
