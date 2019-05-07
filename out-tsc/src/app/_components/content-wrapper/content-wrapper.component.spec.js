import { async, TestBed } from '@angular/core/testing';
import { ContentWrapperComponent } from './content-wrapper.component';
describe('ContentWrapperComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [ContentWrapperComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(ContentWrapperComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=content-wrapper.component.spec.js.map