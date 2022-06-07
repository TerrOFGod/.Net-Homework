import React, {useState} from 'react';
import {SubmitHandler, useForm} from "react-hook-form";
import {Employment} from "../entities/Employment";
import {Pledge} from '../entities/Pledge';
import {useNavigate} from "react-router-dom";
import CheckService from "../services/CheckService";
import {Purpose} from "../entities/Purpose";

interface IFormInput {
    name: string;
    surname: string;
    patronymic: string;
    series: number;
    number: number;
    issued: string;
    date: Date;
    registration: string;
    age: number;
    credit: number;
    purpose: string;
}

const Questionnaire = () => {
    const { register, handleSubmit, formState: { errors } } = useForm<IFormInput>({mode: 'onBlur'});
    const onSubmit: SubmitHandler<IFormInput> = data => console.log(data);

    let defaultDate = new Date()
    defaultDate.setDate(defaultDate.getDate() + 3)

    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [patronymic, setPatronymic] = useState('');
    const [issued, setIssued] = useState('');
    const [registration, setRegistration] = useState('');
    const [purpose, setPurpose] = useState<Purpose>(Purpose.CC);
    const [series, setSeries] = useState(0);
    const [number, setNumber] = useState(0);
    const [age, setAge] = useState(0);
    const [credit, setCredit] = useState(0);
    const [autoAge, setAutoAge] = useState(0);
    const [date, setDate] = useState(defaultDate);
    const [criminal, setCriminal] = useState(false);
    const [other, setOther] = useState(false);
    const [employment, setEmployment] = useState<Employment>(Employment.Unemployed);
    const [pledge, setPledge] = useState<Pledge>(Pledge.RE);

    const nav = useNavigate()

    const onClickCheckButton = async (e : React.MouseEvent) => {
        e.preventDefault();
        const nameCleaned = name.trim();
        const descriptionCleaned = surname.trim();
        const patronymicCleaned = patronymic.trim();
        const issuedCleaned = issued.trim();
        const registrationCleaned = registration.trim();
        const purposeCleaned = purpose;
        const seriesCleaned = series;
        const numberCleaned = number;
        const ageCleaned = age;
        const creditCleaned = credit;
        const autoAgeCleaned = autoAge;
        const dateCleaned = date;
        const criminalCleaned = criminal;
        const otherCleaned = other;
        const employmentCleaned = employment;
        const pledgeCleaned = pledge;

        await CheckService.CheckAsync({
            name: nameCleaned,
            surname: descriptionCleaned,
            patronymic: patronymicCleaned,
            issued: issuedCleaned,
            registration: registrationCleaned,
            purpose: purposeCleaned,
            series: seriesCleaned,
            number: numberCleaned,
            age: ageCleaned,
            credit: creditCleaned,
            autoAge: autoAgeCleaned,
            date: dateCleaned,
            criminal: criminalCleaned,
            other: otherCleaned,
            employment: employmentCleaned,
            pledge: pledgeCleaned,
        }).then(x => {
            alert('Successfully checked')
            nav(`/result`)
        }).catch(err => {
            console.error(err)
            alert('Could not get result')
        })

    }

    return (
        <div>
            <form onSubmit={handleSubmit(onSubmit)}>
                <div id={'fio'}>
                    <div className='m-0 ms-4'>
                        <label>Name: </label>
                        <input className='border rounded my-2 col-9 me-4 p-1'
                               type='text'
                               placeholder={'Name'}
                               onInput={e => {
                                   setName(e.currentTarget.value)
                               }}
                               {...register("name", { required: true, minLength: 6, maxLength: 20 })}/>
                        {
                            errors?.name?.type === "required" &&
                            <p className='text-danger'>This field is required</p>
                        }
                        {
                            errors?.name?.type === "minLength" &&
                            <p className='text-danger'>This field must have at least 6 symbols</p>
                        }
                        {
                            errors?.name?.type === "maxLength" &&
                            <p className='text-danger'>This field is too long(maximum length is 20 ch)</p>
                        }
                    </div>
                    <div className='m-0 ms-4'>
                        <label>Surname: </label>
                        <input className='border rounded my-2 col-9 me-4 p-1'
                               type='text'
                               placeholder={'Surname'}
                               onInput={e => {
                                   setSurname(e.currentTarget.value)
                               }}
                               {...register("surname", { required: true, minLength: 6, maxLength: 20 })}/>
                        {
                            errors?.surname?.type === "required" &&
                            <p className='text-danger'>This field is required</p>
                        }
                        {
                            errors?.surname?.type === "minLength" &&
                            <p className='text-danger'>This field must have at least 6 symbols</p>
                        }
                        {
                            errors?.surname?.type === "maxLength" &&
                            <p className='text-danger'>This field is too long(maximum length is 20 ch)</p>
                        }
                    </div>
                    <div className='m-0 ms-4'>
                        <label>Patronymic: </label>
                        <input className='border rounded my-2 col-9 me-4 p-1'
                               type='text'
                               placeholder={'Patronymic'}
                               onInput={e => {
                                   setPatronymic(e.currentTarget.value)
                               }}
                               {...register("patronymic", { required: true, minLength: 6, maxLength: 20 })}/>
                        {
                            errors?.patronymic?.type === "required" &&
                            <p className='text-danger'>This field is required</p>
                        }
                        {
                            errors?.patronymic?.type === "minLength" &&
                            <p className='text-danger'>This field must have at least 6 symbols</p>
                        }
                        {
                            errors?.patronymic?.type === "maxLength" &&
                            <p className='text-danger'>This field is too long(maximum length is 20 ch)</p>
                        }
                    </div>
                </div>

                <div id={'passport'}>
                    <div className='m-0 ms-4'>
                        <label>Series: </label>
                        <input className='border rounded my-2 col-9 me-4 p-1'
                               type='number'
                               placeholder={'Series'}
                               onInput={e => {
                                   setSeries(+e.currentTarget.value)
                               }}
                               {...register("series", { required: true, minLength: 6, maxLength: 20 })}/>
                        {
                            errors?.series?.type === "required" &&
                            <p className='text-danger'>This field is required</p>
                        }
                        {
                            errors?.series?.type === "minLength" &&
                            <p className='text-danger'>This field must have at least 6 symbols</p>
                        }
                        {
                            errors?.series?.type === "maxLength" &&
                            <p className='text-danger'>This field is too long(maximum length is 20 ch)</p>
                        }
                    </div>
                    <div className='m-0 ms-4'>
                        <label>Number: </label>
                        <input className='border rounded my-2 col-9 me-4 p-1'
                               type='number'
                               placeholder={'Number'}
                               onInput={e => {
                                   setNumber(+e.currentTarget.value)
                               }}
                               {...register("number", { required: true, minLength: 6, maxLength: 20 })}/>
                        {
                            errors?.number?.type === "required" &&
                            <p className='text-danger'>This field is required</p>
                        }
                        {
                            errors?.number?.type === "minLength" &&
                            <p className='text-danger'>This field must have at least 6 symbols</p>
                        }
                        {
                            errors?.number?.type === "maxLength" &&
                            <p className='text-danger'>This field is too long(maximum length is 20 ch)</p>
                        }
                    </div>
                    <div className='m-0 ms-4'>
                        <label>Issued by: </label>
                        <input className='border rounded my-2 col-9 me-4 p-1'
                               type='text'
                               placeholder={'Issued by'}
                               onInput={e => {
                                   setIssued(e.currentTarget.value)
                               }}
                               {...register("issued", { required: true, minLength: 6, maxLength: 20 })}/>
                        {
                            errors?.issued?.type === "required" &&
                            <p className='text-danger'>This field is required</p>
                        }
                        {
                            errors?.issued?.type === "minLength" &&
                            <p className='text-danger'>This field must have at least 6 symbols</p>
                        }
                        {
                            errors?.issued?.type === "maxLength" &&
                            <p className='text-danger'>This field is too long(maximum length is 20 ch)</p>
                        }
                    </div>
                    <div className='m-0 ms-4'>
                        <label>Date of issue: </label>
                        <input className='border rounded my-2 col-9 me-4 p-1'
                               type='date'
                               value={date.toLocaleDateString('en-CA')}
                               onInput={e => {
                                   setDate(new Date(e.currentTarget.value))
                               }}
                               {...register("date", { required: true, minLength: 6, maxLength: 20 })}/>
                        {
                            errors?.date?.type === "required" &&
                            <p className='text-danger'>This field is required</p>
                        }
                        {
                            errors?.date?.type === "minLength" &&
                            <p className='text-danger'>This field must have at least 6 symbols</p>
                        }
                        {
                            errors?.date?.type === "maxLength" &&
                            <p className='text-danger'>This field is too long(maximum length is 20 ch)</p>
                        }
                    </div>
                    <div className='m-0 ms-4'>
                        <label>Registration information: </label>
                        <input className='border rounded my-2 col-9 me-4 p-1'
                               type='date'
                               value={date.toLocaleDateString('en-CA')}
                               onInput={e => {
                                   setRegistration(e.currentTarget.value)
                               }}
                               {...register("registration", { required: true, minLength: 6, maxLength: 20 })}/>
                        {
                            errors?.registration?.type === "required" &&
                            <p className='text-danger'>This field is required</p>
                        }
                        {
                            errors?.registration?.type === "minLength" &&
                            <p className='text-danger'>This field must have at least 6 symbols</p>
                        }
                        {
                            errors?.registration?.type === "maxLength" &&
                            <p className='text-danger'>This field is too long(maximum length is 20 ch)</p>
                        }
                    </div>
                </div>

                <div className='m-0 ms-4' id={'age'}>
                    <label>Age: </label>
                    <input className='border rounded my-2 col-9 me-4 p-1'
                           type='number'
                           placeholder={'Age'}
                           onInput={e => {
                               setAge(+e.currentTarget.value)
                           }}
                           {...register("age", { required: true, minLength: 6, maxLength: 20 })}/>
                    {
                        errors?.age?.type === "required" &&
                        <p className='text-danger'>This field is required</p>
                    }
                    {
                        errors?.age?.type === "minLength" &&
                        <p className='text-danger'>This field must have at least 6 symbols</p>
                    }
                    {
                        errors?.age?.type === "maxLength" &&
                        <p className='text-danger'>This field is too long(maximum length is 20 ch)</p>
                    }
                </div>

                <div className='m-0 ms-4' id={'criminal'}>
                    <label>Criminal record: </label>
                    <input className='border rounded my-2 col-9 me-4 p-1'
                           type='checkbox'
                           checked={criminal}
                           onInput={e => {
                               setCriminal(!criminal)
                           }}/>
                </div>

                <div className='m-0 ms-4' id={'credit'}>
                    <label>Credit amount: </label>
                    <input className='border rounded my-2 col-9 me-4 p-1'
                           type='number'
                           placeholder={'Credit amount'}
                           onInput={e => {
                               setCredit(+e.currentTarget.value)
                           }}
                           {...register("credit", { required: true, min: 0})}/>
                    {
                        errors?.credit?.type === "required" &&
                        <p className='text-danger'>This field is required</p>
                    }
                    {
                        errors?.credit?.type === "min" &&
                        <p className='text-danger'>This field must be not negative</p>
                    }
                </div>

                <div className='m-0 ms-4' id={'purpose'}>
                    <label>Purpose: </label>
                    <select className='border rounded my-2 col-9 me-4 p-1'
                            onInput={e => {
                                setPurpose(e.currentTarget.value as Purpose)
                            }}>
                        <option value={Purpose.CC}>Consumer credit</option>
                        <option value={Purpose.RE}>Real estate</option>
                        <option value={Purpose.OL}>On-lending</option>
                    </select>
                </div>

                <div className='m-0 ms-4' id={'employment'}>
                    <label>Employment: </label>
                    <select className='border rounded my-2 col-9 me-4 p-1'
                            onInput={e => {
                                setEmployment(e.currentTarget.value as Employment)
                            }}>
                        <option value={Employment.Unemployed}>Unemployed</option>
                        <option value={Employment.IE}>Individual enterprise</option>
                        {/*LC = Labor Code*/}
                        <option value={Employment.LCRF}>Agreement of the LC of the RF</option>
                        <option value={Employment.Freelancer}>Freelancer</option>
                        <option value={Employment.Pensioner}>Pensioner</option>
                        <option value={Employment.WA}>Without an agreement</option>
                    </select>
                </div>

                <div className='m-0 ms-4' id={'other'}>
                    <label>Other credits: </label>
                    <input className='border rounded my-2 col-9 me-4 p-1'
                           type='checkbox'
                           checked={other}
                           onInput={e => {
                               setOther(!other)
                           }}/>
                </div>

                <div className='m-0 ms-4' id={'pledge'}>
                    <label>Pledge: </label>
                    <select className='border rounded my-2 col-9 me-4 p-1'
                            onInput={e => {
                                setPledge(e.currentTarget.value as Pledge)
                            }}>
                        <option value={Pledge.RE}>Real estate</option>
                        <option value={Pledge.Automobile}>Automobile</option>
                        <option value={Pledge.Guarantee}>Guarantee</option>
                    </select>
                    {
                        pledge == Pledge.Automobile ?
                        <input type='number'
                               placeholder={'Credit amount'}
                               onInput={e => {
                                   setAutoAge(+e.currentTarget.value)
                               }}/>
                        : ''
                    }
                </div>

                <div className={'justify-content-center d-flex'} id={'submit'}>
                    {!(errors.name || errors.surname || errors.patronymic || errors.series || errors.number
                    || errors.issued || errors.date || errors.registration || errors.age || errors.credit
                        || errors.purpose)?
                        <button className='btn btn-primary justify-content-center my-2'
                                onClick={onClickCheckButton}>
                            Check
                        </button>
                        :
                        <button className='btn btn-primary justify-content-center my-2'
                                disabled>
                            Check
                        </button>
                    }
                </div>
            </form>
        </div>
    );
};

export default Questionnaire;