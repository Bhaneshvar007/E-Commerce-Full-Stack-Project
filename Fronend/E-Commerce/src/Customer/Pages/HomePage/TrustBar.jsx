import { Truck, ShieldCheck, RotateCcw } from "lucide-react"

export default function TrustBar() {
  return (
    <section className="bg-(--secondary)/50 border-t border-b border-(--border)">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
          <div className="flex items-start gap-4 text-center md:text-left">
            <Truck className="w-6 h-6 text-blue-700 shrink-0 mt-0.5" />
            <div>
              <p className="font-semibold text-(--foreground)">Free Shipping</p>
              <p className="text-sm text-muted-[var(--foreground)]">On orders over $50 worldwide</p>
            </div>
          </div>
          
          <div className="flex items-start gap-4 text-center md:text-left">
            <ShieldCheck className="w-6 h-6 text-blue-700 shrink-0 mt-0.5" />
            <div>
              <p className="font-semibold text-(--foreground)">Secure Payment</p>
              <p className="text-sm text-muted-[var(--foreground)]">SSL encrypted transactions</p>
            </div>
          </div>

          <div className="flex items-start gap-4 text-center md:text-left">
            <RotateCcw className="w-6 h-6 text-blue-700 shrink-0 mt-0.5" />
            <div>
              <p className="font-semibold text-(--foreground)">Easy Returns</p>
              <p className="text-sm text-muted-[var(--foreground)]">30-day return policy</p>
            </div>
          </div>
        </div>
      </div>
    </section>
  )
}
