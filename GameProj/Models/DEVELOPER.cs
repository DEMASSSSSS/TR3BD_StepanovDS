//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameProj.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DEVELOPER
    {
        public int DVLP_ID { get; set; }
        public string FIO_DVLP { get; set; }
        public string PASSPORT_DVLP { get; set; }
        public string LNG { get; set; }
        public Nullable<int> SALARY_DVLP { get; set; }
        public Nullable<bool> LEADER { get; set; }
        public Nullable<int> EXPERIENCE { get; set; }
        public string EDUCATION { get; set; }
        public Nullable<int> TEAM_ID_DVLP { get; set; }
    
        public virtual TEAM_DVLP TEAM_DVLP { get; set; }
    }
}
