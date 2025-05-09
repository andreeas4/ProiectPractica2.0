using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace ProiectPractica.Shared
{
    public class InputSelectMultiple<TValue> : ComponentBase
    {
        [Parameter] public List<TValue> Value { get; set; } = new();
        [Parameter] public EventCallback<List<TValue>> ValueChanged { get; set; }
        [Parameter] public Expression<Func<List<TValue>>>? ValueExpression { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object>? AdditionalAttributes { get; set; }

        private void OnChange(ChangeEventArgs e)
        {
            var selected = e.Value?.ToString()?.Split(',') ?? Array.Empty<string>();
            var result = selected.Select(v => (TValue)Convert.ChangeType(v, typeof(TValue))).ToList();

            Value = result;
            ValueChanged.InvokeAsync(Value);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "select");
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "multiple", "multiple");
            builder.AddAttribute(3, "onchange", EventCallback.Factory.Create<ChangeEventArgs>(this, OnChange));
            builder.AddContent(4, ChildContent);
            builder.CloseElement();
        }
    }
}
