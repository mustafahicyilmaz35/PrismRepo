using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SekreterPrism.Models;

namespace SekreterPrism.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetContactListAsync();
        List<Contact> GetContactList();
    }
}
