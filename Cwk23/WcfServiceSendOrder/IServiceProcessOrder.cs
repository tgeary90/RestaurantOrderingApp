using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TabletApplication;

namespace WcfServiceSendOrder
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceProcessOrder
    {
        [OperationContract]
        string GetData(int value);
        
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        string sendOrder(int orderNo, string Waiter);

        [OperationContract]
        string sendMeal(int mealNo, int mealType, double mealPrice, int orderNo, int tableNo);

        [OperationContract]
        int[] getReadyOrders();

        [OperationContract]
        string updateOrder(int orderNo);

        [OperationContract]
        string clearOrders();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
