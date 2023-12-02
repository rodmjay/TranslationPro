// checkout.js

window.translationProStripe = {

    test: function() {
        alert('test');
    },

    initialize: async function(stripeKey, clientSecret) {
        const stripe = Stripe(stripeKey);

        console.log(clientSecret);
        
        const checkout = await stripe.initEmbeddedCheckout({
            clientSecret
        });

        checkout.mount('#checkout');
    }

};

