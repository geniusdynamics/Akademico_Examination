using System;

namespace exams
{
    public partial class WaitForm1
    {
        class _failedMemberConversionMarker1
        {
        }
#error Cannot convert ConstructorBlockSyntax - see comment for details
        /* Cannot convert ConstructorBlockSyntax, CONVERSION ERROR: Value cannot be null.
        Parameter name: parameterList in 'Sub New\r\n  Me.InitializeC...' at character 28
           at Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ConstructorDeclaration(SyntaxList`1 attributeLists, SyntaxTokenList modifiers, SyntaxToken identifier, ParameterListSyntax parameterList, ConstructorInitializerSyntax initializer, BlockSyntax body, ArrowExpressionClauseSyntax expressionBody, SyntaxToken semicolonToken)
           at Microsoft.CodeAnalysis.CSharp.SyntaxFactory.ConstructorDeclaration(SyntaxList`1 attributeLists, SyntaxTokenList modifiers, SyntaxToken identifier, ParameterListSyntax parameterList, ConstructorInitializerSyntax initializer, BlockSyntax body)
           at ICSharpCode.CodeConverter.CSharp.DeclarationNodeVisitor.<VisitConstructorBlock>d__100.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

        Input:
            Sub New
                Me.InitializeComponent()
                Me.progressPanel1.AutoHeight = True
            End Sub

         */
        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel1.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel1.Description = description;
        }

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        public enum WaitFormCommand
        {
            SomeCommandId
        }
    }
}