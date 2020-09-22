using ContactRecord.Application.DTOs;
using ContactRecord.Application.Interfaces;
using ContactRecord.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactRecord.Application.Services
{
    public class ContactRecordService: IContactRecordService
    {
        private readonly IContactRecordRepository _contactRecordRepository;

        public ContactRecordService(IContactRecordRepository contactRecordRepository)
        {
            _contactRecordRepository = contactRecordRepository;
        }

        public async Task<Core.Entities.ContactRecord> GetByIdAsync(int id)
        {
            return await _contactRecordRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Core.Entities.ContactRecord>> GetAllAsync()
        {
            return await _contactRecordRepository.GetAllAsync();
        }

        public async Task<Core.Entities.ContactRecord> GetByEmailAsync(string email)
        {
            return await _contactRecordRepository.GetByEmailAsync(email);
        }

        public async Task<IEnumerable<Core.Entities.ContactRecord>> GetByStateOrCityAsync(string stateOrCity)
        {
            return await _contactRecordRepository.GetByStateOrCityAsync(stateOrCity);
        }

        public async Task<int> AddAsync(CreateContactRecordInput input) 
        {
            var existContactRecord = await _contactRecordRepository.GetByEmailAsync(input.Email);

            //TO-DO: Create own Exception
            if (existContactRecord != null)
                throw new Exception("ContactRecord alerady exists");

            //TO-DO: Use Automapper
            var address = new Core.ValueObjects.Address(input.Address.State, input.Address.City, input.Address.ZipCode, input.Address.Street, input.Address.Number);
            var phoneNumber = new Core.ValueObjects.PhoneNumber(input.PhoneNumber.PersonalNumber, input.PhoneNumber.WorkNumber);
            var contactRecord = new Core.Entities.ContactRecord(input.Name, input.Company, input.ProfileImagePath, input.Email, input.BirthDate, phoneNumber, address);

            await _contactRecordRepository.AddAsync(contactRecord);

            return await _contactRecordRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(UpdateContactRecordInput input)
        {
            var contactRecordToUpdate = await _contactRecordRepository.GetByIdAsync(input.Id);

            //TO-DO: Create own Exception
            if (contactRecordToUpdate == null)
                throw new Exception("ContactRecord doesn't exists");

            //TO-DO: Use Automapper
            var address = new Core.ValueObjects.Address(input.Address.State, input.Address.City, input.Address.ZipCode, input.Address.Street, input.Address.Number);
            var phoneNumber = new Core.ValueObjects.PhoneNumber(input.PhoneNumber.PersonalNumber, input.PhoneNumber.WorkNumber);

            contactRecordToUpdate.Name = input.Name;
            contactRecordToUpdate.Email = input.Email;
            contactRecordToUpdate.ProfileImagePath = input.ProfileImagePath;
            contactRecordToUpdate.Company = input.Company;
            contactRecordToUpdate.BirthDate = input.BirthDate;
            contactRecordToUpdate.Address = address;
            contactRecordToUpdate.PhoneNumber = phoneNumber;
            
            _contactRecordRepository.Update(contactRecordToUpdate);

            return await _contactRecordRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var contactRecordToDelete = await _contactRecordRepository.GetByIdAsync(id);

            //TO-DO: Create own Exception
            if (contactRecordToDelete == null)
                throw new Exception("ContactRecord doesn't exists");

            _contactRecordRepository.Delete(contactRecordToDelete);

            return await _contactRecordRepository.UnitOfWork.SaveChangesAsync();
        }

    }
}
