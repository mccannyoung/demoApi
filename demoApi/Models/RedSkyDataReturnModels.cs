using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoApi.Models
{
    public class RedSkyDataReturnModels
    {

        public class BundleComponents
        {
            public bool is_assortment { get; set; }
            public bool is_kit_master { get; set; }
            public bool is_standard_item { get; set; }
            public bool is_component { get; set; }
        }

        public class ProductDescription
        {
            public string title { get; set; }
            public List<string> bullet_description { get; set; }
            public string general_description { get; set; }
        }

        public class Variation
        {
        }

        public class Image
        {
            public string base_url { get; set; }
            public string primary { get; set; }
        }

        public class SalesClassificationNode
        {
            public string node_id { get; set; }
            public string wcs_id { get; set; }
        }

        public class Enrichment
        {
            public List<Image> images { get; set; }
            public List<SalesClassificationNode> sales_classification_nodes { get; set; }
        }

        public class Handling
        {
        }

        public class RecallCompliance
        {
            public bool is_product_recalled { get; set; }
        }

        public class TaxCategory
        {
            public string tax_class { get; set; }
            public int tax_code_id { get; set; }
            public string tax_code { get; set; }
        }

        public class DisplayOption
        {
            public bool is_size_chart { get; set; }
            public bool is_warranty { get; set; }
        }

        public class Fulfillment
        {
            public bool is_po_box_prohibited { get; set; }
            public string po_box_prohibited_message { get; set; }
        }

        public class PackageDimensions
        {
            public string weight { get; set; }
            public string weight_unit_of_measure { get; set; }
            public string width { get; set; }
            public string depth { get; set; }
            public string height { get; set; }
            public string dimension_unit_of_measure { get; set; }
        }

        public class EnvironmentalSegmentation
        {
            public bool is_lead_disclosure { get; set; }
        }

        public class Manufacturer
        {
        }

        public class ItemType
        {
            public string category_type { get; set; }
            public int type { get; set; }
            public string name { get; set; }
        }

        public class ProductClassification
        {
            public string product_type { get; set; }
            public string product_type_name { get; set; }
            public string item_type_name { get; set; }
            public ItemType item_type { get; set; }
        }

        public class ProductBrand
        {
            public string brand { get; set; }
        }

        public class Attributes
        {
            public string gift_wrapable { get; set; }
            public string has_prop65 { get; set; }
            public string is_hazmat { get; set; }
            public int max_order_qty { get; set; }
            public string street_date { get; set; }
            public string media_format { get; set; }
            public string merch_class { get; set; }
            public int merch_subclass { get; set; }
            public string return_method { get; set; }
        }

        public class Hold
        {
            public bool is_active { get; set; }
        }

        public class EligibilityRules
        {
            public Hold hold { get; set; }
        }

        public class ReturnPolicies
        {
            public string user { get; set; }
            public string policyDays { get; set; }
            public string guestMessage { get; set; }
        }

        public class Item
        {
            public string tcin { get; set; }
            public BundleComponents bundle_components { get; set; }
            public string dpci { get; set; }
            public string upc { get; set; }
            public ProductDescription product_description { get; set; }
            public string parent_items { get; set; }
            public string buy_url { get; set; }
            public Variation variation { get; set; }
            public Enrichment enrichment { get; set; }
            public string return_method { get; set; }
            public Handling handling { get; set; }
            public RecallCompliance recall_compliance { get; set; }
            public TaxCategory tax_category { get; set; }
            public DisplayOption display_option { get; set; }
            public Fulfillment fulfillment { get; set; }
            public PackageDimensions package_dimensions { get; set; }
            public EnvironmentalSegmentation environmental_segmentation { get; set; }
            public Manufacturer manufacturer { get; set; }
            public ProductClassification product_classification { get; set; }
            public ProductBrand product_brand { get; set; }
            public string item_state { get; set; }
            public List<object> specifications { get; set; }
            public Attributes attributes { get; set; }
            public string country_of_origin { get; set; }
            public string relationship_type_code { get; set; }
            public bool subscription_eligible { get; set; }
            public List<object> ribbons { get; set; }
            public List<object> tags { get; set; }
            public string estore_item_status_code { get; set; }
            public EligibilityRules eligibility_rules { get; set; }
            public ReturnPolicies return_policies { get; set; }
        }

        public class Product
        {
            public Item item { get; set; }
        }

        public class RootObject
        {
            public Product product { get; set; }
        }
    }
}
