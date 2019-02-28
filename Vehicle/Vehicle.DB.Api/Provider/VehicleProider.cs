using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.DB.repository;

namespace Vehicle.DB.Api.Provider
{
    public class VehicleProider: IVehicleProider
    {
        private readonly IVehicleQueryFactory _vehicleFactory;
        private readonly IStatusQueryFactory _statusFactory;
        private readonly ICustomerQueryFactory _customerFactory;

        public VehicleProider(IVehicleQueryFactory vehicleFactory, IStatusQueryFactory statusFactory, ICustomerQueryFactory customerFactory)
        {
            _vehicleFactory = vehicleFactory;
            _customerFactory = customerFactory;
            _statusFactory = statusFactory;
        }

        public List<Models.Vehicle> GetAll()
        {
            var result = _vehicleFactory.GetAllVehicls().ToList();
            this.SetObjects(result);
            return result;
        }

        public List<Models.Vehicle> GetByStatusId(Int32 id)
        {
            var result = _vehicleFactory.GetVehicleByStatusId(id).ToList();
            this.SetObjects(result);
            return result;
        }

        public List<Models.Vehicle> GetByCustomerId(Int64 id)
        {
            var result =  _vehicleFactory.GetVehicleByCustomerId(id).ToList();
            this.SetObjects(result);
            return result;
        }

        public bool UpdateVehicleStatus(Models.Vehicle vehicle)
        {
            return _vehicleFactory.UpdateVehicleStatus(vehicle);
        }

        public List<Models.Vehicle> GetVehicleByStatusAndCustomerId(Int32 statusId, Int64 customerId)
        {
            var result = _vehicleFactory.GetVehicleByStatusAndCustomerId(statusId, customerId).ToList();
            this.SetObjects(result);
            return result;
        }

        private void SetObjects(List<Models.Vehicle> items)
        {
            foreach (var item in items)
            {
                var status = _statusFactory.GetStatusByID(item.StatusRefID);
                item.VehicleStatus = status;
                var customer = _customerFactory.GetCustomersById(item.CustomerRefID);
                item.VehicleCustomer = customer;
            }
        }
    }
}
