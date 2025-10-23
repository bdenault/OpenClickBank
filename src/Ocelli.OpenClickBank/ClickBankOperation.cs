namespace Ocelli.OpenClickBank;

/// <summary>
/// Describes a single ClickBank endpoint by the method and route template.
/// </summary>
public sealed class ClickBankOperation
{
    public string Template { get; }
    public HttpMethod Method { get; }

    private ClickBankOperation(HttpMethod method, string route)
    {
        Method = method;
        Template = route;
    }

    /// <summary>Operation for <c>GET /rest/1.3/analytics/status</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsStatus =
        new(HttpMethod.Get, "/rest/1.3/analytics/status");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/subscription/details/compthirty</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsSubscriptionDetailsCompThirty =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/subscription/details/compthirty");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/subscription/details/compsixty</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsSubscriptionDetailsCompSixty =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/subscription/details/compsixty");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/subscription/details/cancelthirty</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsSubscriptionDetailsCancelThirty =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/subscription/details/cancelthirty");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/subscription/details/cancelsixty</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsSubscriptionDetailsCancelSixty =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/subscription/details/cancelsixty");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/subscription/details/startdate</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsSubscriptionDetailsStartDate =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/subscription/details/startdate");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/subscription/details/canceldate</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsSubscriptionDetailsCancelDate =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/subscription/details/canceldate");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/subscription/details/nextpmtdate</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsSubscriptionDetailsNextPaymentDate =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/subscription/details/nextpmtdate");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/subscription/details/status</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsSubscriptionDetailsStatus =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/subscription/details/status");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/subscription/details</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsSubscriptionDetails =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/subscription/details");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/subscription/trends</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsSubscriptionTrends =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/subscription/trends");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/{dimension}</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsByRoleAndDimension =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/{dimension}");

    /// <summary>Operation for <c>GET /rest/1.3/analytics/{role}/{dimension}/summary</c>.</summary>
    public static readonly ClickBankOperation GetAnalyticsByRoleAndDimensionSummary =
        new(HttpMethod.Get, "/rest/1.3/analytics/{role}/{dimension}/summary");

    /// <summary>Operation for <c>GET /rest/1.3/debug</c>.</summary>
    public static readonly ClickBankOperation GetDebug =
        new(HttpMethod.Get, "/rest/1.3/debug");

    /// <summary>Operation for <c>GET /rest/1.3/images/list</c>.</summary>
    public static readonly ClickBankOperation GetImagesList =
        new(HttpMethod.Get, "/rest/1.3/images/list");

    /// <summary>Operation for <c>POST /rest/1.3/orders/{receipt}/reinstate</c>.</summary>
    public static readonly ClickBankOperation PostOrdersReinstate =
        new(HttpMethod.Post, "/rest/1.3/orders/{receipt}/reinstate");

    /// <summary>Operation for <c>POST /rest/1.3/orders/{receipt}/pause</c>.</summary>
    public static readonly ClickBankOperation PostOrdersPause =
        new(HttpMethod.Post, "/rest/1.3/orders/{receipt}/pause");

    /// <summary>Operation for <c>POST /rest/1.3/orders/{receipt}/extend</c>.</summary>
    public static readonly ClickBankOperation PostOrdersExtend =
        new(HttpMethod.Post, "/rest/1.3/orders/{receipt}/extend");

    /// <summary>Operation for <c>POST /rest/1.3/orders/{receipt}/changeProduct</c>.</summary>
    public static readonly ClickBankOperation PostOrdersChangeProduct =
        new(HttpMethod.Post, "/rest/1.3/orders/{receipt}/changeProduct");

    /// <summary>Operation for <c>POST /rest/1.3/orders/{receipt}/changeAddress</c>.</summary>
    public static readonly ClickBankOperation PostOrdersChangeAddress =
        new(HttpMethod.Post, "/rest/1.3/orders/{receipt}/changeAddress");

    /// <summary>Operation for <c>GET /rest/1.3/orders/count</c>.</summary>
    public static readonly ClickBankOperation GetOrdersCount =
        new(HttpMethod.Get, "/rest/1.3/orders/count");

    /// <summary>Operation for <c>GET /rest/1.3/orders/list</c>.</summary>
    public static readonly ClickBankOperation GetOrdersList =
        new(HttpMethod.Get, "/rest/1.3/orders/list");

    /// <summary>Operation for <c>HEAD /rest/1.3/orders/{receipt}</c>.</summary>
    public static readonly ClickBankOperation HeadOrdersByReceipt =
        new(HttpMethod.Head, "/rest/1.3/orders/{receipt}");

    /// <summary>Operation for <c>GET /rest/1.3/orders/{receipt}</c>.</summary>
    public static readonly ClickBankOperation GetOrdersByReceipt =
        new(HttpMethod.Get, "/rest/1.3/orders/{receipt}");

    /// <summary>Operation for <c>GET /rest/1.3/orders/{receipt}/upsells</c>.</summary>
    public static readonly ClickBankOperation GetOrdersUpsells =
        new(HttpMethod.Get, "/rest/1.3/orders/{receipt}/upsells");

    /// <summary>Operation for <c>POST /rest/1.3/orders2/{receipt}/changeAddress</c>.</summary>
    public static readonly ClickBankOperation PostOrders2ChangeAddress =
        new(HttpMethod.Post, "/rest/1.3/orders2/{receipt}/changeAddress");

    /// <summary>Operation for <c>POST /rest/1.3/orders2/{receipt}/changeDate</c>.</summary>
    public static readonly ClickBankOperation PostOrders2ChangeDate =
        new(HttpMethod.Post, "/rest/1.3/orders2/{receipt}/changeDate");

    /// <summary>Operation for <c>POST /rest/1.3/orders2/{receipt}/changeProduct</c>.</summary>
    public static readonly ClickBankOperation PostOrders2ChangeProduct =
        new(HttpMethod.Post, "/rest/1.3/orders2/{receipt}/changeProduct");

    /// <summary>Operation for <c>POST /rest/1.3/orders2/{receipt}/extend</c>.</summary>
    public static readonly ClickBankOperation PostOrders2Extend =
        new(HttpMethod.Post, "/rest/1.3/orders2/{receipt}/extend");

    /// <summary>Operation for <c>GET /rest/1.3/orders2/{receipt}</c>.</summary>
    public static readonly ClickBankOperation GetOrders2ByReceipt =
        new(HttpMethod.Get, "/rest/1.3/orders2/{receipt}");

    /// <summary>Operation for <c>HEAD /rest/1.3/orders2/{receipt}</c>.</summary>
    public static readonly ClickBankOperation HeadOrders2ByReceipt =
        new(HttpMethod.Head, "/rest/1.3/orders2/{receipt}");

    /// <summary>Operation for <c>GET /rest/1.3/orders2/count</c>.</summary>
    public static readonly ClickBankOperation GetOrders2Count =
        new(HttpMethod.Get, "/rest/1.3/orders2/count");

    /// <summary>Operation for <c>GET /rest/1.3/orders2/list</c>.</summary>
    public static readonly ClickBankOperation GetOrders2List =
        new(HttpMethod.Get, "/rest/1.3/orders2/list");

    /// <summary>Operation for <c>GET /rest/1.3/orders2/{receipt}/upsells</c>.</summary>
    public static readonly ClickBankOperation GetOrders2Upsells =
        new(HttpMethod.Get, "/rest/1.3/orders2/{receipt}/upsells");

    /// <summary>Operation for <c>POST /rest/1.3/orders2/{receipt}/pause</c>.</summary>
    public static readonly ClickBankOperation PostOrders2Pause =
        new(HttpMethod.Post, "/rest/1.3/orders2/{receipt}/pause");

    /// <summary>Operation for <c>POST /rest/1.3/orders2/{receipt}/reinstate</c>.</summary>
    public static readonly ClickBankOperation PostOrders2Reinstate =
        new(HttpMethod.Post, "/rest/1.3/orders2/{receipt}/reinstate");

    /// <summary>Operation for <c>GET /rest/1.3/products/{sku}</c>.</summary>
    public static readonly ClickBankOperation GetProductBySku =
        new(HttpMethod.Get, "/rest/1.3/products/{sku}");

    /// <summary>Operation for <c>PUT /rest/1.3/products/{sku}</c>.</summary>
    public static readonly ClickBankOperation PutProductBySku =
        new(HttpMethod.Put, "/rest/1.3/products/{sku}");

    /// <summary>Operation for <c>DELETE /rest/1.3/products/{sku}</c>.</summary>
    public static readonly ClickBankOperation DeleteProductBySku =
        new(HttpMethod.Delete, "/rest/1.3/products/{sku}");

    /// <summary>Operation for <c>GET /rest/1.3/products/list</c>.</summary>
    public static readonly ClickBankOperation GetProductsList =
        new(HttpMethod.Get, "/rest/1.3/products/list");

    /// <summary>Operation for <c>GET /rest/1.3/quickstats/count</c>.</summary>
    public static readonly ClickBankOperation GetQuickstatsCount =
        new(HttpMethod.Get, "/rest/1.3/quickstats/count");

    /// <summary>Operation for <c>GET /rest/1.3/quickstats/accounts</c>.</summary>
    public static readonly ClickBankOperation GetQuickstatsForAccount =
        new(HttpMethod.Get, "/rest/1.3/quickstats/accounts");

    /// <summary>Operation for <c>GET /rest/1.3/quickstats/list</c>.</summary>
    public static readonly ClickBankOperation GetQuickstatsList =
        new(HttpMethod.Get, "/rest/1.3/quickstats/list");

    /// <summary>Operation for <c>GET /rest/1.3/shipping/count</c>.</summary>
    public static readonly ClickBankOperation GetShippingCount =
        new(HttpMethod.Get, "/rest/1.3/shipping/count");

    /// <summary>Operation for <c>GET /rest/1.3/shipping/list</c>.</summary>
    public static readonly ClickBankOperation GetShippingList =
        new(HttpMethod.Get, "/rest/1.3/shipping/list");

    /// <summary>Operation for <c>POST /rest/1.3/shipping/shipnotice/{receipt}</c>.</summary>
    public static readonly ClickBankOperation PostShippingShipNotice =
        new(HttpMethod.Post, "/rest/1.3/shipping/shipnotice/{receipt}");

    /// <summary>Operation for <c>GET /rest/1.3/shipping/shipnotice/{receipt}</c>.</summary>
    public static readonly ClickBankOperation GetShippingShipNotice =
        new(HttpMethod.Get, "/rest/1.3/shipping/shipnotice/{receipt}");

    /// <summary>Operation for <c>GET /rest/1.3/shipping2/count</c>.</summary>
    public static readonly ClickBankOperation GetShipping2Count =
        new(HttpMethod.Get, "/rest/1.3/shipping2/count");

    /// <summary>Operation for <c>GET /rest/1.3/shipping2/list</c>.</summary>
    public static readonly ClickBankOperation GetShipping2List =
        new(HttpMethod.Get, "/rest/1.3/shipping2/list");

    /// <summary>Operation for <c>POST /rest/1.3/shipping2/shipnotice/{receipt}</c>.</summary>
    public static readonly ClickBankOperation PostShipping2ShipNotice =
        new(HttpMethod.Post, "/rest/1.3/shipping2/shipnotice/{receipt}");

    /// <summary>Operation for <c>GET /rest/1.3/shipping2/shipnotice/{receipt}</c>.</summary>
    public static readonly ClickBankOperation GetShipping2ShipNotice =
        new(HttpMethod.Get, "/rest/1.3/shipping2/shipnotice/{receipt}");

    /// <summary>Operation for <c>GET /rest/1.3/shipping3/count</c>.</summary>
    public static readonly ClickBankOperation GetShipping3Count =
        new(HttpMethod.Get, "/rest/1.3/shipping3/count");

    /// <summary>Operation for <c>GET /rest/1.3/shipping3/list</c>.</summary>
    public static readonly ClickBankOperation GetShipping3List =
        new(HttpMethod.Get, "/rest/1.3/shipping3/list");

    /// <summary>Operation for <c>POST /rest/1.3/shipping3/shipnotice/{receipt}</c>.</summary>
    public static readonly ClickBankOperation PostShipping3ShipNotice =
        new(HttpMethod.Post, "/rest/1.3/shipping3/shipnotice/{receipt}");

    /// <summary>Operation for <c>GET /rest/1.3/shipping3/shipnotice/{receipt}</c>.</summary>
    public static readonly ClickBankOperation GetShipping3ShipNotice =
        new(HttpMethod.Get, "/rest/1.3/shipping3/shipnotice/{receipt}");

    /// <summary>Operation for <c>POST /rest/1.3/tickets/{receipt}</c>.</summary>
    public static readonly ClickBankOperation PostTicketByReceipt =
        new(HttpMethod.Post, "/rest/1.3/tickets/{receipt}");

    /// <summary>Operation for <c>GET /rest/1.3/tickets/{id}</c>.</summary>
    public static readonly ClickBankOperation GetTicketById =
        new(HttpMethod.Get, "/rest/1.3/tickets/{id}");

    /// <summary>Operation for <c>PUT /rest/1.3/tickets/{id}</c>.</summary>
    public static readonly ClickBankOperation PutTicketById =
        new(HttpMethod.Put, "/rest/1.3/tickets/{id}");

    /// <summary>Operation for <c>GET /rest/1.3/tickets/count</c>.</summary>
    public static readonly ClickBankOperation GetTicketsCount =
        new(HttpMethod.Get, "/rest/1.3/tickets/count");

    /// <summary>Operation for <c>GET /rest/1.3/tickets/list</c>.</summary>
    public static readonly ClickBankOperation GetTicketsList =
        new(HttpMethod.Get, "/rest/1.3/tickets/list");

    /// <summary>Operation for <c>GET /rest/1.3/tickets/refundAmounts/{receipt}</c>.</summary>
    public static readonly ClickBankOperation GetTicketRefundAmountsByReceipt =
        new(HttpMethod.Get, "/rest/1.3/tickets/refundAmounts/{receipt}");

    /// <summary>Operation for <c>POST /rest/1.3/tickets/{id}/returned</c>.</summary>
    public static readonly ClickBankOperation PostTicketReturnedById =
        new(HttpMethod.Post, "/rest/1.3/tickets/{id}/returned");
}
