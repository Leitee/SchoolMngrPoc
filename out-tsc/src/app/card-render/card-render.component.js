import * as tslib_1 from "tslib";
import { Component, Input } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
var CardRenderComponent = /** @class */ (function () {
    function CardRenderComponent(breakpointObserver) {
        this.breakpointObserver = breakpointObserver;
        this.classListSource = [];
        /** Based on the screen size, switch from standard to one column per row */
        this.cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(map(function (_a) {
            var matches = _a.matches;
            if (matches) {
                return [
                    { title: 'Card 1', cols: 1, rows: 1 },
                    { title: 'Card 2', cols: 1, rows: 1 },
                    { title: 'Card 3', cols: 1, rows: 1 },
                    { title: 'Card 4', cols: 1, rows: 1 }
                ];
            }
            return [
                { title: 'Card 1', cols: 1, rows: 1 },
                { title: 'Card 2', cols: 1, rows: 1 },
                { title: 'Card 3', cols: 1, rows: 1 },
                { title: 'Card 4', cols: 1, rows: 1 }
            ];
        }));
    }
    tslib_1.__decorate([
        Input(),
        tslib_1.__metadata("design:type", Array)
    ], CardRenderComponent.prototype, "classListSource", void 0);
    CardRenderComponent = tslib_1.__decorate([
        Component({
            selector: 'app-card-render',
            templateUrl: './card-render.component.html',
            styleUrls: ['./card-render.component.css']
        }),
        tslib_1.__metadata("design:paramtypes", [BreakpointObserver])
    ], CardRenderComponent);
    return CardRenderComponent;
}());
export { CardRenderComponent };
//# sourceMappingURL=card-render.component.js.map