//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldChaCha
{
    using System;
    using System.Collections.Generic;
    
    public partial class Production
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Production()
        {
            this.NecessaryMaterials = new HashSet<NecessaryMaterials>();
        }
    
        public int IDПроизводства { get; set; }
        public int IDПродукции { get; set; }
        public Nullable<System.TimeSpan> Время { get; set; }
        public Nullable<double> Себестоимость { get; set; }
        public Nullable<int> НомерЦеха { get; set; }
        public Nullable<int> НеобходимоеКолЧел { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NecessaryMaterials> NecessaryMaterials { get; set; }
        public virtual Products Products { get; set; }
    }
}