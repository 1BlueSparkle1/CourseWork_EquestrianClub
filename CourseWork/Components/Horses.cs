//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWork.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Horses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Horses()
        {
            this.Horses1 = new HashSet<Horses>();
            this.Horses11 = new HashSet<Horses>();
            this.LevelTrainingHorses = new HashSet<LevelTrainingHorses>();
            this.SignTrainings = new HashSet<SignTrainings>();
        }
    
        public int Id { get; set; }
        public string Moniker { get; set; }
        public System.DateTime DateOfBirthday { get; set; }
        public Nullable<int> HorseGenderId { get; set; }
        public Nullable<int> StallId { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<int> MotherId { get; set; }
        public Nullable<int> FatherId { get; set; }
        public string Description { get; set; }
        public string ImageSourse { get; set; }
        public Nullable<int> PositionStableId { get; set; }
    
        public virtual HorseGender HorseGender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horses> Horses1 { get; set; }
        public virtual Horses Horses2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horses> Horses11 { get; set; }
        public virtual Horses Horses3 { get; set; }
        public virtual PositionStable PositionStable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LevelTrainingHorses> LevelTrainingHorses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SignTrainings> SignTrainings { get; set; }
    }
}
