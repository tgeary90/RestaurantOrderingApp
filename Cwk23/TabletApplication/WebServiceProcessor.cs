using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TabletApplication
{
    class WebServiceProcessor
    {
        // communication to the web service is offloaded from the tablet to this class.
        // This facilitates good OOD practise by decoupling form from web service provider.

        // get our web service proxy object to call web methods against

        ServiceReferenceProcessOrder.ServiceProcessOrderClient wsClient 
            = new ServiceReferenceProcessOrder.ServiceProcessOrderClient();
        
        // Send order to webservice for adding to remote db. The kitchen can then prepare it.

        public string sendOrder_local(int _orderNo, string _waiter)
        {
            return wsClient.sendOrder(_orderNo, _waiter);
        }      
    
        // send meal to web service for statistics analysis

        public void sendMeal_local(int _mealNo, int _mealType, double _mealPrice, int _orderNo, int _tableNo)
        {
           wsClient.sendMeal(_mealNo, _mealType, _mealPrice, _orderNo, _tableNo);
        }

        // return an array of the orders the kitchen has prepared
        
        public int[] getReadyOrders_local()
        {
            return wsClient.getReadyOrders();
        }

        // An order has been delivered so we need to notify 
        // the kitchen.

        public void updateOrder_local(int _deliveredOrderNo)
        {
            wsClient.updateOrder(_deliveredOrderNo);
        }

        // clear all orders at remote db by web method call.

        public void clearOrders_local()
        {
            wsClient.clearOrders();
        }
    }
}
