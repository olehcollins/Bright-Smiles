# Flow Chart

![FlowChart](./flowchart.svg)

## Flow Chart

```xml
    <?xml version="1.0" encoding="UTF-8"?>
    <mxfile host="app.diagrams.net">
        <diagram name="Main Flow">
            <mxGraphModel dx="1061" dy="694" grid="1" gridSize="10" guides="1" tooltips="1" connect="1" arrows="1" fold="1" page="1" pageScale="1" pageWidth="827" pageHeight="1169" math="0" shadow="0">
                <root>
                    <mxCell id="0" />
                    <mxCell id="1" parent="0" />
                    <mxCell id="2" value="User selects 'Sign In'" style="rounded=0;whiteSpace=wrap;html=1;" vertex="1" parent="1">
                    <mxGeometry x="160" y="50" width="140" height="40" as="geometry" />
                    </mxCell>
                    <mxCell id="3" value="System requests Username/Password" style="rounded=0;whiteSpace=wrap;html=1;" vertex="1" parent="1">
                    <mxGeometry x="160" y="120" width="200" height="40" as="geometry" />
                    </mxCell>
                    <mxCell id="4" value="User enters Username/Password" style="rounded=0;whiteSpace=wrap;html=1;" vertex="1" parent="1">
                    <mxGeometry x="160" y="190" width="160" height="40" as="geometry" />
                    </mxCell>
                    <mxCell id="5" value="System verifies Username/Password" style="rhombus;whiteSpace=wrap;html=1;" vertex="1" parent="1">
                    <mxGeometry x="160" y="260" width="180" height="80" as="geometry" />
                    </mxCell>
                    <mxCell id="6" value="Invalid login, re-render login view with error message" style="rounded=0;whiteSpace=wrap;html=1;" vertex="1" parent="1">
                    <mxGeometry x="430" y="260" width="220" height="60" as="geometry" />
                    </mxCell>
                    <mxCell id="7" value="Valid login, redirect to Homepage" style="rounded=0;whiteSpace=wrap;html=1;" vertex="1" parent="1">
                    <mxGeometry x="160" y="400" width="220" height="40" as="geometry" />
                    </mxCell>
                    <mxCell id="8" value="System checks if Username is Admin" style="rhombus;whiteSpace=wrap;html=1;" vertex="1" parent="1">
                    <mxGeometry x="160" y="470" width="180" height="80" as="geometry" />
                    </mxCell>
                    <mxCell id="9" value="System allows access to Admin functions" style="rounded=0;whiteSpace=wrap;html=1;" vertex="1" parent="1">
                    <mxGeometry x="160" y="580" width="200" height="40" as="geometry" />
                    </mxCell>
                    <mxCell id="10" value="System allows access to User functions" style="rounded=0;whiteSpace=wrap;html=1;" vertex="1" parent="1">
                    <mxGeometry x="430" y="580" width="200" height="40" as="geometry" />
                    </mxCell>
                    <mxCell id="11" value="End" style="ellipse;whiteSpace=wrap;html=1;" vertex="1" parent="1">
                    <mxGeometry x="160" y="660" width="60" height="40" as="geometry" />
                    </mxCell>
                    <mxCell id="12" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;html=1;" edge="1" parent="1" source="2" target="3">
                    <mxGeometry relative="1" as="geometry" />
                    </mxCell>
                    <mxCell id="13" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;html=1;" edge="1" parent="1" source="3" target="4">
                    <mxGeometry relative="1" as="geometry" />
                    </mxCell>
                    <mxCell id="14" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;html=1;" edge="1" parent="1" source="4" target="5">
                    <mxGeometry relative="1" as="geometry" />
                    </mxCell>
                    <mxCell id="15" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;html=1;" edge="1" parent="1" source="5" target="6">
                    <mxGeometry relative="1" as="geometry" />
                    </mxCell>
                    <mxCell id="16" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;html=1;" edge="1" parent="1" source="5" target="7">
                    <mxGeometry relative="1" as="geometry" />
                    </mxCell>
                    <mxCell id="17" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;html=1;" edge="1" parent="1" source="7" target="8">
                    <mxGeometry relative="1" as="geometry" />
                    </mxCell>
                    <mxCell id="18" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;html=1;" edge="1" parent="1" source="8" target="9">
                    <mxGeometry relative="1" as="geometry" />
                    </mxCell>
                    <mxCell id="19" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;html=1;" edge="1" parent="1" source="8" target="10">
                    <mxGeometry relative="1" as="geometry" />
                    </mxCell>
                    <mxCell id="20" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;html=1;" edge="1" parent="1" source="9" target="11">
                    <mxGeometry relative="1" as="geometry" />
                    </mxCell>
                    <mxCell id="21" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;html=1;" edge="1" parent="1" source="10" target="11">
                    <mxGeometry relative="1" as="geometry" />
                    </mxCell>
                    <mxCell id="22" style="edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;html=1;" edge="1" parent="1" source="6" target="3">
                    <mxGeometry relative="1" as="geometry" />
                    </mxCell>
                </root>
            </mxGraphModel>
        </diagram>
    </mxfile>
```
