#pragma checksum "D:\OOP\ShopAppWeb\Pages\Checkout\Payment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b7ada3e01c2e0c3b0571012ae71fe48f8f98d4b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ShopAppWeb.Pages.Checkout.Pages_Checkout_Payment), @"mvc.1.0.razor-page", @"/Pages/Checkout/Payment.cshtml")]
namespace ShopAppWeb.Pages.Checkout
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\OOP\ShopAppWeb\Pages\_ViewImports.cshtml"
using ShopAppWeb;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b7ada3e01c2e0c3b0571012ae71fe48f8f98d4b", @"/Pages/Checkout/Payment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9710ce58354286c85f1e4fbc07c65775220310a0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Checkout_Payment : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("payment-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!-- Display a payment form -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b7ada3e01c2e0c3b0571012ae71fe48f8f98d4b3394", async() => {
                WriteLiteral(@"
    <div id=""card-element""><!--Stripe.js injects the Card Element--></div>
    <button id=""submit"">
        <div class=""spinner hidden"" id=""spinner""></div>
        <span id=""button-text"">Pay now</span>
    </button>
    <p id=""card-error"" role=""alert""></p>
    <p class=""result-message hidden"">
        payment succeeded, see the result in your
        <a");
                BeginWriteAttribute("href", " href=\"", 485, "\"", 492, 0);
                EndWriteAttribute();
                WriteLiteral(" target=\"_blank\">stripe dashboard.</a> refresh the page to pay again.\r\n    </p>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script src=""https://js.stripe.com/v3/""></script>
    <script src=""https://polyfill.io/v3/polyfill.min.js?version=3.52.1&features=fetch""></script>


    <script>
       // A reference to Stripe.js initialized with your real test publishable API key.
var stripe = Stripe(""");
#nullable restore
#line 33 "D:\OOP\ShopAppWeb\Pages\Checkout\Payment.cshtml"
                Write(Model.PublicKey);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""");

// The items the customer wants to buy
var purchase = {
  items: [{ id: ""xl-tshirt"" }]
};

// Disable the button until we have Stripe set up on the page
document.querySelector(""button"").disabled = true;
fetch(""/create-payment-intent"", {
  method: ""POST"",
  headers: {
    ""Content-Type"": ""application/json""
  },
  body: JSON.stringify(purchase)
})
  .then(function(result) {
    return result.json();
  })
  .then(function(data) {
    var elements = stripe.elements();

    var style = {
      base: {
        color: ""#32325d"",
        fontFamily: 'Arial, sans-serif',
        fontSmoothing: ""antialiased"",
        fontSize: ""16px"",
        ""::placeholder"": {
          color: ""#32325d""
        }
      },
      invalid: {
        fontFamily: 'Arial, sans-serif',
        color: ""#fa755a"",
        iconColor: ""#fa755a""
      }
    };

    var card = elements.create(""card"", { style: style });
    // Stripe injects an iframe into the DOM
    card.mount(""#card-element"");

    ");
                WriteLiteral(@"card.on(""change"", function (event) {
      // Disable the Pay button if there are no card details in the Element
      document.querySelector(""button"").disabled = event.empty;
      document.querySelector(""#card-error"").textContent = event.error ? event.error.message : """";
    });

    var form = document.getElementById(""payment-form"");
    form.addEventListener(""submit"", function(event) {
      event.preventDefault();
      // Complete payment when the submit button is clicked
      payWithCard(stripe, card, data.clientSecret);
    });
  });

// Calls stripe.confirmCardPayment
// If the card requires authentication Stripe shows a pop-up modal to
// prompt the user to enter authentication details without leaving your page.
var payWithCard = function(stripe, card, clientSecret) {
  loading(true);
  stripe
    .confirmCardPayment(clientSecret, {
      payment_method: {
        card: card
      }
    })
    .then(function(result) {
      if (result.error) {
        // Show error to you");
                WriteLiteral(@"r customer
        showError(result.error.message);
      } else {
        // The payment succeeded!
        orderComplete(result.paymentIntent.id);
      }
    });
};

/* ------- UI helpers ------- */

// Shows a success message when the payment is complete
var orderCoModelpPublicKeyPublicKeyublicKeylete = function(paymentIntentId) {
  loading(false);
  document
    .querySelector("".result-message a"")
    .setAttribute(
      ""href"",
      ""https://dashboard.stripe.com/test/payments/"" + paymentIntentId
    );
  document.querySelector("".result-message"").classList.remove(""hidden"");
  document.querySelector(""button"").disabled = true;
};

// Show the customer the error from Stripe if their card fails to charge
var showError = function(errorMsgText) {
  loading(false);
  var errorMsg = document.querySelector(""#card-error"");
  errorMsg.textContent = errorMsgText;
  setTimeout(function() {
    errorMsg.textContent = """";
  }, 4000);
};

// Show a spinner on payment submission
var l");
                WriteLiteral(@"oading = function(isLoading) {
  if (isLoading) {
    // Disable the button and show a spinner
    document.querySelector(""button"").disabled = true;
    document.querySelector(""#spinner"").classList.remove(""hidden"");
    document.querySelector(""#button-text"").classList.add(""hidden"");
  } else {
    document.querySelector(""button"").disabled = false;
    document.querySelector(""#spinner"").classList.add(""hidden"");
    document.querySelector(""#button-text"").classList.remove(""hidden"");
  }
};

    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopAppWeb.Pages.Checkout.PaymentModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShopAppWeb.Pages.Checkout.PaymentModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShopAppWeb.Pages.Checkout.PaymentModel>)PageContext?.ViewData;
        public ShopAppWeb.Pages.Checkout.PaymentModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
