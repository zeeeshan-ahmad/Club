using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Club.data_access;
using Club.model;

namespace Club.business_logic
{
    internal class MemberBL
    {

        private MemberDAO memberDAO;

        public MemberBL()
        {
            memberDAO = new MemberDAO();
        }
        public bool Save(Member M)
        {
            bool result = memberDAO.Save(M);
            return result;
        }

        public Member SearchById(int id)
        {
            Member M = memberDAO.SearchById(id);

            return M;
        }

        public bool Update(Member M)
        {
            bool result = memberDAO.Update(M);
            return result;
        }

        public bool Delete(int id)
        {
            bool result = memberDAO.Delete(id);
            return result;
        }
    }
}
 