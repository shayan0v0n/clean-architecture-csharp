using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CleanArchitectureTemplate.Domain.Enums
{
    public enum Messages
    {
        [Description("اجباری است")]
        Required,
        [Description("رکوردی یافت نشد.")]
        NotFound,
        [Description("رکوردی به روزرسانی نشد.")]
        UpdateFailed,
        [Description("رکوردی اضافه نشد.")]
        InsertFailed,
        [Description("رکوردی حذف نشد.")]
        DeleteFailed,
        [Description("رکورد تکراری - رکوردی اضافه نشد.")]
        Duplicate,
        [Description("اطلاعات وارد شده صحیح نمی باشد.")]
        BadRequest,
        [Description("عملیات با موفقیت انجام شد.")]
        Ok,
        [Description("امکان حذف وجود ندارد، ایتم مورد نظر در بخش دیگری استفاده شده است .")]
        HasChild,
        [Description("گزینه ای انتخاب نشده است")]
        IsNull,
        [Description("عملیات با مشکل مواجه شد")]
        Error,
        [Description("الستیک با مشکل مواجه شد")]
        ElasticError,
        [Description("استفاده از این ایتم بیش از حد مجاز است")]
        LimitExceeded,
        [Description("اطلاعات امنیتی وارد شده صحیح نمی باشد.")]
        Unauthorize,
        [Description("کد برای شما قبلا ارسال شده است چند دقیقه دیگر امتحان کنید .")]
        IsSentCode,
        [Description("زمان استفاده از این قابلیت گذشته است .")]
        TimeOut,
        [Description("زمان استفاده از این قابلیت فرا نرسیده است .")]
        TimeOutNew,
        [Description("خطای همزمانی شخص دیگری زودتر این ایتم را رزروکرده")]
        ConcurrencyError,
        [Description("امکان ویرایش وجود ندارد این ایتم قفل شده است")]
        IsLocked,
        [Description("نوع فایل معتبر نیست")]
        InvalidTypeFile,
        [Description("تعداد دفعات استفاد پیش از حد مجاز است")]
        Finished,

        #region User
        [Description("ابتدا وارد حساب کاربری خود شوید")]
        NotLogin,
        [Description("لینک تایید منقضی شده است، لطفا مجدد اطلاعات حساب خود را وارد کنید تا لینک تایید برای شما ارسال گردد")]
        NotValid,
        [Description("کاربر موردنظر وجود ندارد")]
        NotFoundUser,
        [Description("نام کاربری تکراری می باشد")]
        UserExisted,
        [Description("ایمیل یا رمز عبور صحیح نیست")]
        NotExist,
        [Description("ایمیل معتبر نیست")]
        NoValidEmail,
        [Description("رمز عبور امن نیست")]
        NoValidPass,
        [Description("اطلاعات پروفایل خود را تکمیل کنید")]
        NotCompletedProfile,
        [Description("فروشنده مجاز به ثبت سیمکارت است")]
        ValidSeller,
        [Description("در انتظار تایید اطلاعات هویتی")]
        WaitAcceptProfile,
        [Description("در انتظار تایید ایمیل")]
        WaitConfirmEmail,
        [Description("شماره شبا معتبر نیست")]
        ShabaNotValid,
        [Description("ابتدا باید بدهی خود را به ستاره سیم پرداخت کنید")]
        UserDebtor,
        [Description("کاربر گرامی قبلا با این کد ملی ثبت نام کرده اید")]
        NationalCodeDuplicate,
        [Description("کاربر گرامی کدملی شما معتبر نیست")]
        NotValidNationalCode,
        [Description("حساب کاربری شما قفل شده است لطفا تا دقایقی دیگر دوباره سعی کنید")]
        Locked,
        [Description("نام کاربری معتبر نیست")]
        UserNotValid,
        [Description("سیمکارت ثبت شده در اطلاعات کاربری قابل فروش نیست")]
        UserSimNumber,
        #endregion
        #region products
        [Description("قابل رزرو نیست")]
        NotValidReserve,
        [Description("این سیمکارت ها قبلا فروخته شده است.")]
        SoldSimcards,
        [Description("پرداخت نهایی نشد و سیمکارت ها از رزرو خارج شد")]
        NotPay,
        [Description("پرداخت نهایی نشد")]
        NotCompletePay,
        [Description("استرداد بعد از تحویل امکان پذیر میباشد")]
        RefundAfterDelivery
        #endregion

    }
}
