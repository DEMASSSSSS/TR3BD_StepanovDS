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
    
    public partial class ARTIST
    {
        public int ARTST_ID { get; set; }
        public string FIO_ARTST { get; set; }
        public string PASSPORT_ARTST { get; set; }
        public Nullable<int> SALARY_ARTST { get; set; }
        public Nullable<int> TEAM_ID_ARTST { get; set; }
    
        public virtual TEAM_ARTST TEAM_ARTST { get; set; }
    }
}
