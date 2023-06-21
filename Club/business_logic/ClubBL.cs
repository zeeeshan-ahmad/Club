using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Club.data_access;
using Club.model;

namespace Club.business_logic
{
    class ClubBL
    {
        private ClubDAO clubDAO;

        public ClubBL()
        {
            clubDAO = new ClubDAO();
        }


        public bool Save(ClubModel p)
        {
            return clubDAO.Save(p);

        }

        public ClubModel SearchById(int id)
        {
            ClubModel p = clubDAO.SearchById(id);

            return p;
        }

        public bool Update(ClubModel p)
        {
            return clubDAO.Update(p);
        }

        public bool Delete(int id)
        {
            return clubDAO.Delete(id);
        }

      
      }
    }
