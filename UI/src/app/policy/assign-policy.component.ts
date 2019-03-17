import { Component, Input, OnInit, AfterViewInit } from '@angular/core';
import { Policy, Customer } from '@app/_models';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AssignPolicyService, CustomerService } from '@app/_services';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { AssignPolicy } from '@app/_models/assign-policy';
import { DatePipe } from '@angular/common';
import { ConfirmationDialogService } from '@app/_helpers';

@Component({ templateUrl: 'assign-policy.component.html' })
export class AssignPolicyComponent implements OnInit, AfterViewInit {
    @Input() policyList: Policy[];
    customerList: Customer[];
    assignmentPolicyList: AssignPolicy[];

    assignPolicyForm: FormGroup;
    submitted = false;
    loading = false;
    now = new Date();
    today = new Date(this.now.getFullYear(), this.now.getMonth(), this.now.getDate());
    dueDate: string = '';

    columns: string[] = ['Policy', 'Customer', 'Effective Start Date', 'Due Date', 'Options'];

    constructor(
        private confirmationDialogService: ConfirmationDialogService,
        private assignPolicyService: AssignPolicyService,
        private customerService: CustomerService,
        private formBuilder: FormBuilder,
        public activeModal: NgbActiveModal,
        private toastr: ToastrService,
        public datepipe: DatePipe
    ) { }

    ngOnInit() {
        this.assignPolicyForm = this.formBuilder.group({
            CustomerID: ['', Validators.required],
            PolicyID: ['', Validators.required],
            EffectiveStartDate: ['', Validators.required]
        });
    }

    ngAfterViewInit() {
        this.customerService.getCustomers()
            .subscribe(customers => {
                this.customerList = customers;
            });

        this.getAssignmentPolicies();
    }

    getAssignmentPolicies() {
        this.assignPolicyService.getPoliciesAssignment()
            .subscribe(assignment => {
                this.assignmentPolicyList = assignment;
            });
    }

    setDueDate() {
        var selectedPolicy = this.policyList.filter(x => x.PolicyID == this.form.PolicyID.value);
        if (!selectedPolicy) return;

        var calculatedDueDate = <Date>this.form.EffectiveStartDate.value;
        if (!calculatedDueDate) return;

        calculatedDueDate.setMonth(calculatedDueDate.getMonth() + selectedPolicy[0].CoverageTerm);
        calculatedDueDate.setDate(calculatedDueDate.getDate() - 1);
        this.dueDate = this.datepipe.transform(calculatedDueDate, 'MM/dd/yyyy');
    }

    get form() { return this.assignPolicyForm.controls; }

    onSubmit() {
        this.submitted = true;

        if (this.assignPolicyForm.invalid) { return; }

        this.loading = true;

        var startDate = <Date>this.form.EffectiveStartDate.value;
        startDate.setDate(startDate.getDate() + 1);

        var dataPolicy = {
            CustomerPolicyID: 0,
            CustomerID: this.form.CustomerID.value,
            PolicyID: this.form.PolicyID.value,
            EffectiveStartDate: this.datepipe.transform(startDate, 'MM/dd/yyyy'),
            DueDate: this.dueDate
        };

        this.assignPolicyService.assignPolicy(dataPolicy)
            .subscribe(
                () => {
                    this.toastr.success("The Policy was successfully assigned to the customer.");
                    this.activeModal.close("Ok");
                },
                error => {
                    this.toastr.error(error);
                    this.loading = false;
                }
            );
    }

    delete(assignPolicy: AssignPolicy) {
        this.confirmationDialogService.confirm('Please confirm..',
            'Do you really want to remove the association?', "Yes", "No")
            .then((result: boolean) => {
                if (result) {
                    this.assignPolicyService.unassignPolicy(assignPolicy.CustomerPolicyID)
                        .subscribe(
                            () => {
                                this.toastr.success('Association successfully removed.');
                                this.getAssignmentPolicies();
                            }
                        );
                }
            });
    }
}