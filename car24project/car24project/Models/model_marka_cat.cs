//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace car24project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class model_marka_cat
    {
        public int id { get; set; }
        public int cat_id { get; set; }
        public int marka_id { get; set; }
        public int model_id { get; set; }
    
        public virtual cat cat { get; set; }
        public virtual marka marka { get; set; }
        public virtual model model { get; set; }
    }
}
