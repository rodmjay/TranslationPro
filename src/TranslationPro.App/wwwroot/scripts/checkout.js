

// This is your test publishable API key.
const stripe = Stripe("pk_test_51O8nvSDGyTHfODiYsM301ojdxnPSmdJ7fl8IB2RBjX3fVmWqm8KFCeZQeAcmE49jZnjllm1v8ae2RZBOxfXdUW2V00z9OY89Yv");

initialize();

// Create a Checkout Session as soon as the page loads
async function initialize() {
    const response = await fetch("/create-checkout-session", {
        method: "POST",
    });

    const { clientSecret } = await response.json();

    const checkout = await stripe.initEmbeddedCheckout({
        clientSecret,
    });

    // Mount Checkout
    checkout.mount('#checkout');
}