using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Club.data_access;

namespace Club.model
{
    class Member
    {
        private int _Id;
        private int _Club_id;
        private string _Address;
        private string _Phone;
        private string _Email;
        private char _Gender;

        public Member()
        {
        }

        public Member( int id, int club_id, string address, string phone, string email, char gender )
        {
            _Id = id;
            _Club_id = club_id;
            _Address = address;
            _Phone = phone;
            _Email = email;
            _Gender = gender;
        }
        public int Id { get => _Id; set => _Id = value; }
        public int Club_Id { get => _Club_id; set => _Club_id = value; }
        public string Address { get => _Address; set => _Address = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public string Email { get => _Email; set => _Email = value; }
        public char Gender { get => _Gender; set => _Gender = value; }
        
        }
    }
