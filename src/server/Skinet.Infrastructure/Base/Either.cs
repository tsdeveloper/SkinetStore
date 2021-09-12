namespace Skinet.Infrastructure.Base
{
    public struct Either<TL, TR>
    {
        internal  TL Left { get; }
        internal  TR Right { get; }

        /*public Options<TL> OptionalLeft => IsLeft ? Some(Left) : None;
        public Options<TR> OptionalRight => IsRight ? Some(Right) : None;

        public bool IsLeft { get;}
        public bool IsRight => !IsLeft;

        private Either(TL left)
        {
            IsLeft = true;
            Left = left;
            Right = default(TR);
        }
        
        private Either(TR right)
        {
            IsLeft = true;
            Right = right;
            Left = default(TL);
        }

        public TResult Match<TResult>(Func<TL, TResult> left, Func<TR, TResult> right)
            => IsLeft ? left(Left) : right(Right);
        
        public static implicit operator */
    }
}