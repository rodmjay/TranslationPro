// checkout.js

window.translationProStripe = {
    
    initialize: async function(stripeKey, clientSecret) {
        const stripe = Stripe(stripeKey);

        console.log(clientSecret);
        
        const checkout = await stripe.initEmbeddedCheckout({
            clientSecret
        });

        checkout.mount('#checkout');
    }

};

