using System;
using System.Collections.Generic;

namespace africanrancher.Models.Domain
{
    public class Bovine
    {
        protected bool Equals(Bovine other)
        {
            return string.Equals(NickName, other.NickName) && string.Equals(EarTag, other.EarTag) && string.Equals(Bolus, other.Bolus) && string.Equals(Brand, other.Brand) && BirthDate.Equals(other.BirthDate) && string.Equals(Breed, other.Breed) && WeeningDate.Equals(other.WeeningDate) && Death.Equals(other.Death) && Sale.Equals(other.Sale) && Purchase.Equals(other.Purchase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Bovine) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (NickName != null ? NickName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (EarTag != null ? EarTag.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Bolus != null ? Bolus.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Brand != null ? Brand.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ BirthDate.GetHashCode();
                hashCode = (hashCode*397) ^ (Breed != null ? Breed.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ WeeningDate.GetHashCode();
                hashCode = (hashCode*397) ^ Death.GetHashCode();
                hashCode = (hashCode*397) ^ Sale.GetHashCode();
                hashCode = (hashCode*397) ^ Purchase.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Bovine left, Bovine right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Bovine left, Bovine right)
        {
            return !Equals(left, right);
        }

        public int Id { get; set; }
        public string NickName { get; set; }
        public string EarTag { get; set; }
        public string Bolus { get; set; }

        public string Brand { get; set; }


        public MaleBovine Sire { get; set; }


        public FemaleBovine Dam { get; set; }

        public DateTimeOffset? BirthDate { get; set; }

        public string Breed { get; set; }
        public DateTimeOffset? WeeningDate { get; set; }
        
        public DateTimeOffset? Death { get; set; }
        public DateTimeOffset? Sale { get; set; }
        public DateTimeOffset? Purchase { get; set; }

        public  List<Weighing> Weighings { get; set; } 
        public List<Ailment> Ailments { get; set; } 
    }
}

