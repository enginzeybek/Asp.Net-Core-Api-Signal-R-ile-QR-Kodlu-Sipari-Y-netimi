using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;
using SignalR.DataAccessLayer.Repository;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

		public int BookingCount()
		{
			using var context = new SignalRContext();

			return context.Bookings.Count();
		}

		public void BookingStatusApproved(int id)
		{
			using var context = new SignalRContext();

			var value = context.Bookings.Find(id);

			value.Description = "Rezervasyon Onaylandı";

			context.SaveChanges();
		}

		public void BookingStatusCanselled(int id)
		{
			using var context = new SignalRContext();

			var value = context.Bookings.Find(id);

			value.Description = "Rezervasyon İptal edildi";

			context.SaveChanges();
		}
	}
}
