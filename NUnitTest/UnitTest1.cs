using Framework.EFCore;
using Framework.EFCore.Entities;
using NUnit.Framework;
using System;
using System.Linq;

namespace NUnitTest
{
    public class Tests
    { 
        private UserRepository _userRepository;
        private IUnitOfWork _unitOfWork;
        [SetUp]
        public void Setup()
        {
            DefaultDbContext  defaultDbContext = new DefaultDbContext();             
            _unitOfWork = new UnitOfWork(defaultDbContext);              
            _userRepository = new UserRepository(_unitOfWork); 
        }

        [Test]
        public void Test_GetAll()
        {
            var aaa= _userRepository.EntitiesAsNoTracking.ToList();
            Assert.Pass();
        }
        [Test]
        public void Test_GetByID()
        {
            var aaa = _userRepository.GetAll();
            var bbb = _userRepository.GetFirstOrDefault(c=>c.Id == 1); 

            Assert.True(aaa != null);
        }

        [Test]
        public void Test_Add()
        {
            var user = new UserEntity
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@doe.com",
                Password = "123",
            };
            var aaa = _userRepository.Insert(user);


            var aaab = _userRepository.GetAll();

            Assert.True(aaa != null);
        }

        [Test]
        public void Test_Update()
        {
           
            var model = _userRepository.GetFirstOrDefault(c=>c.Id == 2);

            model.Email = "123@qq.com";

            var aaa= _userRepository.Update(model);
             
            Assert.True(aaa> 0);
        }

        [Test]
        public void Test_Delete()
        {
            var user = new UserEntity
            {
                FirstName = "John" + new Random().Next(100,999),
                LastName = "Doe" + new Random().Next(100, 999),
                Email = "john@doe.com",
                Password = "123",
            };
            var aaa = _userRepository.Insert(user);

            var model = _userRepository.Delete(1); 

            Assert.True(model > 0);
        }
    }
}