using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ICatProductRepository _catProduct;
        private IProductRepository _product;
        private ISellerRepository _seller;
        private IProductImageRepository _productImage;
        private IColorRepository _color;
        private IProductMeterRepository _productMeter;
        private IProductOfferRepository _productOffer;
        private IProductCustomerCommentsRepository _productCustmerComments;
        private IProductCustomerRateRepositry _productCustomerRate;
        private IProductParametersRepository _productParameters;
        private ISellerCatProductRepository _sellerCatProduct;
        private IStatusRepository _status;
        private IStatusTypeRepository _statusType;
        private ISystemsRepository _systems;
        private ITablesRepository _tables;
        private ICatProductParametersRepository _catProductParameters;
        private ISliderPlaceTypeRepository _sliderPlaceType;
        private ISliderRepository _slider;
        private ICustomerRepository _customer;
        private ICustomerOrderRepository _customerOrder;
        private ICustomerOrderProductRepository _customerOrderProduct;
        private ICustomerOfferRepository _customerOffer;
        private IPostTypeRepository _postType;
        private IPaymentTypeRepository _paymentType;
        private ICustomerOrderPaymentRepository _customerOrderPayment;
        private ICustomerAddressRepository _customerAddress;
        private ILocationRepository _location;



        public ICatProductRepository CatProduct => _catProduct ??= new CatProductRepository(_repoContext);
        public IProductRepository Product => _product ??= new ProductRepository(_repoContext);
        public ISellerRepository Seller => _seller ??= new SellerRepository(_repoContext);
        public IProductImageRepository ProductImage => _productImage ??= new ProductImageRepository(_repoContext);
        public IColorRepository Color => _color ??= new ColorRepository(_repoContext);
        public IProductMeterRepository ProductMeter => _productMeter ??= new ProductMeterRepository(_repoContext);
        public IProductOfferRepository ProductOffer => _productOffer ??= new ProductOfferRepository(_repoContext);
        public IProductCustomerCommentsRepository ProductCustomerComments => _productCustmerComments ??= new ProductCustomerCommentsRepository(_repoContext);
        public IProductCustomerRateRepositry ProductCustomerRate => _productCustomerRate ??= new ProductCustomerRateRepository(_repoContext);
        public IProductParametersRepository ProductParameters => _productParameters ??= new ProductParametersRepository(_repoContext);
        public ISellerCatProductRepository SellerCatProduct => _sellerCatProduct ??= new SellerCatProductRepository(_repoContext);
        public IStatusRepository Status => _status ??= new StatusRepository(_repoContext);
        public IStatusTypeRepository StatusType => _statusType ??= new StatusTypeRepository(_repoContext);
        public ISystemsRepository Systems => _systems ??= new SystemsRepository(_repoContext);
        public ITablesRepository Tables => _tables ??= new TablesRepository(_repoContext);
        public ICatProductParametersRepository CatProductParameters => _catProductParameters ??= new CatProductParametersRepository(_repoContext);
        public ISliderPlaceTypeRepository SliderPlaceType => _sliderPlaceType ??= new SliderPlaceTypeRepository(_repoContext);
        public ISliderRepository Slider => _slider ??= new SliderRepository(_repoContext);
        public ICustomerRepository Customer => _customer ??= new CustomerRepository(_repoContext);
        public ICustomerOrderRepository CustomerOrder => _customerOrder ??= new CustomerOrderRepository(_repoContext);
        public ICustomerOrderProductRepository CustomerOrderProduct => _customerOrderProduct ??= new CustomerOrderProductRepository(_repoContext);
        public ICustomerOfferRepository CustomerOffer => _customerOffer ??= new CustomerOfferRepository(_repoContext);
        public IPostTypeRepository PostType => _postType ??= new PostTypeRepository(_repoContext);
        public IPaymentTypeRepository PaymentType => _paymentType ??= new PaymentTypeRepository(_repoContext);
        public ICustomerOrderPaymentRepository CustomerOrderPayment => _customerOrderPayment ??= new CustomerOrderPaymentRepository(_repoContext);
        public ICustomerAddressRepository CustomerAddress => _customerAddress ??= new CustomerAddressRepository(_repoContext);
        public ILocationRepository Location => _location ??= new LocationRepository(_repoContext);

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;

        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
