using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rattrapage_MCI_cuisine
{
    class MaterielCommun
    {
        private static readonly MaterielCommun instance = new MaterielCommun();

        private Assiette assiettesCreuses;
        private Assiette assiettesPlates;
        private Assiette assiettesDesserts;
        private Assiette assiettesPetites;

        private Couvert couteaux;
        private Couvert cuillieresCafe;
        private Couvert cuillieresSoupe;
        private Couvert fourchettes;

        private Verre verreChampagne;
        private Verre verreEau;
        private Verre verreVin;

        private MaterielCommun()
        {
            assiettesCreuses = new Assiette(150, TypeAssiette.creuse);
            assiettesPlates = new Assiette(150, TypeAssiette.plate);
            assiettesDesserts = new Assiette(150, TypeAssiette.dessert);
            assiettesPetites = new Assiette(150, TypeAssiette.petite);

            couteaux = new Couvert(150, TypeCouvert.couteau);
            cuillieresCafe = new Couvert(150, TypeCouvert.cuilliereCafe);
            cuillieresSoupe = new Couvert(150, TypeCouvert.cuilliereSoupe);
            fourchettes = new Couvert(150, TypeCouvert.fourchette);

            verreChampagne = new Verre(150, TypeVerre.champagne);
            verreChampagne = new Verre(150, TypeVerre.eau);
            verreChampagne = new Verre(150, TypeVerre.vin);
        }

        public MaterielCommun GetMaterielCommun()
        {
            return instance;
        }
        public Assiette AssiettesCreuses { get => assiettesCreuses; set => assiettesCreuses = value; }
        public Assiette AssiettesPlates { get => assiettesPlates; set => assiettesPlates = value; }
        public Assiette AssiettesDesserts { get => assiettesDesserts; set => assiettesDesserts = value; }
        public Assiette AssiettesPetites { get => assiettesPetites; set => assiettesPetites = value; }
        public Couvert Couteaux { get => couteaux; set => couteaux = value; }
        public Couvert CuillieresCafe { get => cuillieresCafe; set => cuillieresCafe = value; }
        public Couvert CuillieresSoupe { get => cuillieresSoupe; set => cuillieresSoupe = value; }
        public Couvert Fourchettes { get => fourchettes; set => fourchettes = value; }
        public Verre VerreChampagne { get => verreChampagne; set => verreChampagne = value; }
        public Verre VerreEau { get => verreEau; set => verreEau = value; }
        public Verre VerreVin { get => verreVin; set => verreVin = value; }
    }
}
