//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WB_API
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registration
    {
        public int RegistrationId { get; set; }
        public int RunnerId { get; set; }
        public System.DateTime RegistrationDateTime { get; set; }
        public Nullable<int> CharityId { get; set; }
    
        public virtual Charity Charity { get; set; }
        public virtual Runner Runner { get; set; }
    }
}
