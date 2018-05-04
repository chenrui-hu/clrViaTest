namespace BanKai.Basic.Common
{
    internal class HideMemberDemoClassBase
    {
        public string MethodToHide()
        {
            return "HideMemberDemoClassBase::MethodToHide()";
        }
    }

    internal class HideMemberDemoClass : HideMemberDemoClassBase
    {
        // hide MethodToHide() in base class, tell compiler it's deliberate and supress the warning
        // of ambiguity
        public new string MethodToHide()
        {
            return "HideMemberDemoClass::MethodToHide()";
        }
    }
}