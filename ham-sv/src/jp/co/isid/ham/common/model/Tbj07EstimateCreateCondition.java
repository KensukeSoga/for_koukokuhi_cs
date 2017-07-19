package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���ψČ�CR����������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj07EstimateCreateCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���ϖ��׊Ǘ�NO */
    private BigDecimal _estdetailseqno = null;

    /** �d�ʎԎ�R�[�h */
    private String _dcarcd = null;

    /** �t�F�C�Y */
    private BigDecimal _phase = null;

    /** �N�� */
    private Date _crdate = null;

    /** �����Ǘ�NO */
    private BigDecimal _sequenceno = null;

    /** �o�̓t���O */
    private String _outflg = null;

    /** ��ʔ��f�t���O */
    private String _classdiv = null;

    /** �\�[�g�� */
    private BigDecimal _sortno = null;

    /** �\�Z���ރR�[�h */
    private String _classcd = null;

    /** �\�Z�\��ڃR�[�h */
    private String _expcd = null;

    /** ��� */
    private String _expense = null;

    /** �ڍ� */
    private String _detail = null;

    /** ���ԊJ�n */
    private Date _kikans = null;

    /** ���ԏI�� */
    private Date _kikane = null;

    /** �_��J�n�N���� */
    private Date _contractdate = null;

    /** �_�����(����) */
    private String _contractterm = null;

    /** ������ */
    private String _seikyu = null;

    /** ��NO */
    private String _orderno = null;

    /** �x���� */
    private String _pay = null;

    /** �S���� */
    private String _username = null;

    /** �����z */
    private BigDecimal _getmoney = null;

    /** �����z�m�F */
    private String _getconf = null;

    /** �������z */
    private BigDecimal _paymoney = null;

    /** �������z�m�F */
    private String _payconf = null;

    /** ���ϋ��z */
    private BigDecimal _estmoney = null;

    /** �������z */
    private BigDecimal _clmmoney = null;

    /** �x����[�i�� */
    private Date _deliverday = null;

    /** �ݒ茎 */
    private Date _setmonth = null;

    /** �敪�R�[�h */
    private String _divcd = null;

    /** �O���[�v�R�[�h */
    private BigDecimal _groupcd = null;

    /** �ݒ�ǃi���o�[ */
    private BigDecimal _stkykno = null;

    /** �c���`�F�b�N */
    private String _egtykflg = null;

    /** ���͒S���R�[�h */
    private BigDecimal _inputtntcd = null;

    /** ���͒S���Җ� */
    private String _inputtntnm = null;

    /** ���l */
    private String _note = null;

    /** �\�Z���ރt���O */
    private String _classcdflg = null;

    /** �\�Z�\��ڃt���O */
    private String _expcdflg = null;

    /** ��ڃt���O */
    private String _expenseflg = null;

    /** �ڍ׃t���O */
    private String _detailflg = null;

    /** ���ԊJ�n�t���O */
    private String _kikansflg = null;

    /** ���ԏI���t���O */
    private String _kikaneflg = null;

    /** �_��J�n�N�����t���O */
    private String _contractdateflg = null;

    /** �_�����(����)�t���O */
    private String _contracttermflg = null;

    /** ������t���O */
    private String _seikyuflg = null;

    /** ��NO�t���O */
    private String _ordernoflg = null;

    /** �x����t���O */
    private String _payflg = null;

    /** �S���҃t���O */
    private String _usernameflg = null;

    /** �����z�t���O */
    private String _getmoneyflg = null;

    /** �������z�t���O */
    private String _paymoneyflg = null;

    /** ���ϋ��z�t���O */
    private String _estmoneyflg = null;

    /** �������z�t���O */
    private String _clmmoneyflg = null;

    /** �x����[�i���t���O */
    private String _deliverdayflg = null;

    /** �ݒ茎�t���O */
    private String _setmonthflg = null;

    /** �敪�t���O */
    private String _divisionflg = null;

    /** �O���[�v�R�[�h�t���O */
    private String _groupcdflg = null;

    /** �ݒ�ǃi���o�[�t���O */
    private String _stkyknoflg = null;

    /** ���͒S���R�[�h�t���O */
    private String _inputtntcdflg = null;

    /** ���l�t���O */
    private String _noteflg = null;

    /** �f�[�^�쐬���� */
    private Date _crtdate = null;

    /** �f�[�^�쐬�� */
    private String _crtnm = null;

    /** �쐬�v���O���� */
    private String _crtapl = null;

    /** �쐬�S����ID */
    private String _crtid = null;

    /** �f�[�^�X�V���� */
    private Date _upddate = null;

    /** �f�[�^�X�V�� */
    private String _updnm = null;

    /** �X�V�v���O���� */
    private String _updapl = null;

    /** �X�V�S����ID */
    private String _updid = null;

    /** �����f�[�^�擾���� */
    private Date _gettime = null;

    /** �^�C���X�^���v�i����j */
    private Date _timstmpss = null;

    /** �X�V�v���O�����i����j */
    private String _updaplss = null;

    /** �X�V�S����ID�i����j */
    private String _updidss = null;

    /** ���ψČ��Ǘ�NO */
    private BigDecimal _estseqno = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj07EstimateCreateCondition() {
    }

    /**
     * ���ϖ��׊Ǘ�NO���擾����
     *
     * @return ���ϖ��׊Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstdetailseqno() {
        return _estdetailseqno;
    }

    /**
     * ���ϖ��׊Ǘ�NO��ݒ肷��
     *
     * @param estdetailseqno ���ϖ��׊Ǘ�NO
     */
    public void setEstdetailseqno(BigDecimal estdetailseqno) {
        this._estdetailseqno = estdetailseqno;
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDcarcd() {
        return _dcarcd;
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param dcarcd �d�ʎԎ�R�[�h
     */
    public void setDcarcd(String dcarcd) {
        this._dcarcd = dcarcd;
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrdate() {
        return _crdate;
    }

    /**
     * �N����ݒ肷��
     *
     * @param crdate �N��
     */
    public void setCrdate(Date crdate) {
        this._crdate = crdate;
    }

    /**
     * �����Ǘ�NO���擾����
     *
     * @return �����Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSequenceno() {
        return _sequenceno;
    }

    /**
     * �����Ǘ�NO��ݒ肷��
     *
     * @param sequenceno �����Ǘ�NO
     */
    public void setSequenceno(BigDecimal sequenceno) {
        this._sequenceno = sequenceno;
    }

    /**
     * �o�̓t���O���擾����
     *
     * @return �o�̓t���O
     */
    public String getOutflg() {
        return _outflg;
    }

    /**
     * �o�̓t���O��ݒ肷��
     *
     * @param outflg �o�̓t���O
     */
    public void setOutflg(String outflg) {
        this._outflg = outflg;
    }

    /**
     * ��ʔ��f�t���O���擾����
     *
     * @return ��ʔ��f�t���O
     */
    public String getClassdiv() {
        return _classdiv;
    }

    /**
     * ��ʔ��f�t���O��ݒ肷��
     *
     * @param classdiv ��ʔ��f�t���O
     */
    public void setClassdiv(String classdiv) {
        this._classdiv = classdiv;
    }

    /**
     * �\�[�g�����擾����
     *
     * @return �\�[�g��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * �\�[�g����ݒ肷��
     *
     * @param sortno �\�[�g��
     */
    public void setSortno(BigDecimal sortno) {
        this._sortno = sortno;
    }

    /**
     * �\�Z���ރR�[�h���擾����
     *
     * @return �\�Z���ރR�[�h
     */
    public String getClasscd() {
        return _classcd;
    }

    /**
     * �\�Z���ރR�[�h��ݒ肷��
     *
     * @param classcd �\�Z���ރR�[�h
     */
    public void setClasscd(String classcd) {
        this._classcd = classcd;
    }

    /**
     * �\�Z�\��ڃR�[�h���擾����
     *
     * @return �\�Z�\��ڃR�[�h
     */
    public String getExpcd() {
        return _expcd;
    }

    /**
     * �\�Z�\��ڃR�[�h��ݒ肷��
     *
     * @param expcd �\�Z�\��ڃR�[�h
     */
    public void setExpcd(String expcd) {
        this._expcd = expcd;
    }

    /**
     * ��ڂ��擾����
     *
     * @return ���
     */
    public String getExpense() {
        return _expense;
    }

    /**
     * ��ڂ�ݒ肷��
     *
     * @param expense ���
     */
    public void setExpense(String expense) {
        this._expense = expense;
    }

    /**
     * �ڍׂ��擾����
     *
     * @return �ڍ�
     */
    public String getDetail() {
        return _detail;
    }

    /**
     * �ڍׂ�ݒ肷��
     *
     * @param detail �ڍ�
     */
    public void setDetail(String detail) {
        this._detail = detail;
    }

    /**
     * ���ԊJ�n���擾����
     *
     * @return ���ԊJ�n
     */
    @XmlElement(required = true, nillable = true)
    public Date getKikans() {
        return _kikans;
    }

    /**
     * ���ԊJ�n��ݒ肷��
     *
     * @param kikans ���ԊJ�n
     */
    public void setKikans(Date kikans) {
        this._kikans = kikans;
    }

    /**
     * ���ԏI�����擾����
     *
     * @return ���ԏI��
     */
    @XmlElement(required = true, nillable = true)
    public Date getKikane() {
        return _kikane;
    }

    /**
     * ���ԏI����ݒ肷��
     *
     * @param kikane ���ԏI��
     */
    public void setKikane(Date kikane) {
        this._kikane = kikane;
    }

    /**
     * �_��J�n�N�������擾����
     *
     * @return �_��J�n�N����
     */
    @XmlElement(required = true, nillable = true)
    public Date getContractdate() {
        return _contractdate;
    }

    /**
     * �_��J�n�N������ݒ肷��
     *
     * @param contractdate �_��J�n�N����
     */
    public void setContractdate(Date contractdate) {
        this._contractdate = contractdate;
    }

    /**
     * �_�����(����)���擾����
     *
     * @return �_�����(����)
     */
    public String getContractterm() {
        return _contractterm;
    }

    /**
     * �_�����(����)��ݒ肷��
     *
     * @param contractterm �_�����(����)
     */
    public void setContractterm(String contractterm) {
        this._contractterm = contractterm;
    }

    /**
     * ��������擾����
     *
     * @return ������
     */
    public String getSeikyu() {
        return _seikyu;
    }

    /**
     * �������ݒ肷��
     *
     * @param seikyu ������
     */
    public void setSeikyu(String seikyu) {
        this._seikyu = seikyu;
    }

    /**
     * ��NO���擾����
     *
     * @return ��NO
     */
    public String getOrderno() {
        return _orderno;
    }

    /**
     * ��NO��ݒ肷��
     *
     * @param orderno ��NO
     */
    public void setOrderno(String orderno) {
        this._orderno = orderno;
    }

    /**
     * �x������擾����
     *
     * @return �x����
     */
    public String getPay() {
        return _pay;
    }

    /**
     * �x�����ݒ肷��
     *
     * @param pay �x����
     */
    public void setPay(String pay) {
        this._pay = pay;
    }

    /**
     * �S���҂��擾����
     *
     * @return �S����
     */
    public String getUsername() {
        return _username;
    }

    /**
     * �S���҂�ݒ肷��
     *
     * @param username �S����
     */
    public void setUsername(String username) {
        this._username = username;
    }

    /**
     * �����z���擾����
     *
     * @return �����z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGetmoney() {
        return _getmoney;
    }

    /**
     * �����z��ݒ肷��
     *
     * @param getmoney �����z
     */
    public void setGetmoney(BigDecimal getmoney) {
        this._getmoney = getmoney;
    }

    /**
     * �����z�m�F���擾����
     *
     * @return �����z�m�F
     */
    public String getGetconf() {
        return _getconf;
    }

    /**
     * �����z�m�F��ݒ肷��
     *
     * @param getconf �����z�m�F
     */
    public void setGetconf(String getconf) {
        this._getconf = getconf;
    }

    /**
     * �������z���擾����
     *
     * @return �������z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPaymoney() {
        return _paymoney;
    }

    /**
     * �������z��ݒ肷��
     *
     * @param paymoney �������z
     */
    public void setPaymoney(BigDecimal paymoney) {
        this._paymoney = paymoney;
    }

    /**
     * �������z�m�F���擾����
     *
     * @return �������z�m�F
     */
    public String getPayconf() {
        return _payconf;
    }

    /**
     * �������z�m�F��ݒ肷��
     *
     * @param payconf �������z�m�F
     */
    public void setPayconf(String payconf) {
        this._payconf = payconf;
    }

    /**
     * ���ϋ��z���擾����
     *
     * @return ���ϋ��z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstmoney() {
        return _estmoney;
    }

    /**
     * ���ϋ��z��ݒ肷��
     *
     * @param estmoney ���ϋ��z
     */
    public void setEstmoney(BigDecimal estmoney) {
        this._estmoney = estmoney;
    }

    /**
     * �������z���擾����
     *
     * @return �������z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getClmmoney() {
        return _clmmoney;
    }

    /**
     * �������z��ݒ肷��
     *
     * @param clmmoney �������z
     */
    public void setClmmoney(BigDecimal clmmoney) {
        this._clmmoney = clmmoney;
    }

    /**
     * �x����[�i�����擾����
     *
     * @return �x����[�i��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDeliverday() {
        return _deliverday;
    }

    /**
     * �x����[�i����ݒ肷��
     *
     * @param deliverday �x����[�i��
     */
    public void setDeliverday(Date deliverday) {
        this._deliverday = deliverday;
    }

    /**
     * �ݒ茎���擾����
     *
     * @return �ݒ茎
     */
    @XmlElement(required = true, nillable = true)
    public Date getSetmonth() {
        return _setmonth;
    }

    /**
     * �ݒ茎��ݒ肷��
     *
     * @param setmonth �ݒ茎
     */
    public void setSetmonth(Date setmonth) {
        this._setmonth = setmonth;
    }

    /**
     * �敪�R�[�h���擾����
     *
     * @return �敪�R�[�h
     */
    public String getDivcd() {
        return _divcd;
    }

    /**
     * �敪�R�[�h��ݒ肷��
     *
     * @param divcd �敪�R�[�h
     */
    public void setDivcd(String divcd) {
        this._divcd = divcd;
    }

    /**
     * �O���[�v�R�[�h���擾����
     *
     * @return �O���[�v�R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupcd() {
        return _groupcd;
    }

    /**
     * �O���[�v�R�[�h��ݒ肷��
     *
     * @param groupcd �O���[�v�R�[�h
     */
    public void setGroupcd(BigDecimal groupcd) {
        this._groupcd = groupcd;
    }

    /**
     * �ݒ�ǃi���o�[���擾����
     *
     * @return �ݒ�ǃi���o�[
     */
    public BigDecimal getStkykno() {
        return _stkykno;
    }

    /**
     * �ݒ�ǃi���o�[��ݒ肷��
     *
     * @param stkykno �ݒ�ǃi���o�[
     */
    public void setStkykno(BigDecimal stkykno) {
        this._stkykno = stkykno;
    }

    /**
     * �c���`�F�b�N���擾����
     *
     * @return �c���`�F�b�N
     */
    public String getEgtykflg() {
        return _egtykflg;
    }

    /**
     * �c���`�F�b�N��ݒ肷��
     *
     * @param egtykflg �c���`�F�b�N
     */
    public void setEgtykflg(String egtykflg) {
        this._egtykflg = egtykflg;
    }

    /**
     * ���͒S���R�[�h���擾����
     *
     * @return ���͒S���R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getInputtntcd() {
        return _inputtntcd;
    }

    /**
     * ���͒S���R�[�h��ݒ肷��
     *
     * @param inputtntcd ���͒S���R�[�h
     */
    public void setInputtntcd(BigDecimal inputtntcd) {
        this._inputtntcd = inputtntcd;
    }

    /**
     * ���͒S���Җ����擾����
     *
     * @return ���͒S���Җ�
     */
    public String getInputtntnm() {
        return _inputtntnm;
    }

    /**
     * ���͒S���Җ���ݒ肷��
     *
     * @param inputtntnm ���͒S���Җ�
     */
    public void setInputtntnm(String inputtntnm) {
        this._inputtntnm = inputtntnm;
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getNote() {
        return _note;
    }

    /**
     * ���l��ݒ肷��
     *
     * @param note ���l
     */
    public void setNote(String note) {
        this._note = note;
    }

    /**
     * �\�Z���ރt���O���擾����
     *
     * @return �\�Z���ރt���O
     */
    public String getClasscdflg() {
        return _classcdflg;
    }

    /**
     * �\�Z���ރt���O��ݒ肷��
     *
     * @param classcdflg �\�Z���ރt���O
     */
    public void setClasscdflg(String classcdflg) {
        this._classcdflg = classcdflg;
    }

    /**
     * �\�Z�\��ڃt���O���擾����
     *
     * @return �\�Z�\��ڃt���O
     */
    public String getExpcdflg() {
        return _expcdflg;
    }

    /**
     * �\�Z�\��ڃt���O��ݒ肷��
     *
     * @param expcdflg �\�Z�\��ڃt���O
     */
    public void setExpcdflg(String expcdflg) {
        this._expcdflg = expcdflg;
    }

    /**
     * ��ڃt���O���擾����
     *
     * @return ��ڃt���O
     */
    public String getExpenseflg() {
        return _expenseflg;
    }

    /**
     * ��ڃt���O��ݒ肷��
     *
     * @param expenseflg ��ڃt���O
     */
    public void setExpenseflg(String expenseflg) {
        this._expenseflg = expenseflg;
    }

    /**
     * �ڍ׃t���O���擾����
     *
     * @return �ڍ׃t���O
     */
    public String getDetailflg() {
        return _detailflg;
    }

    /**
     * �ڍ׃t���O��ݒ肷��
     *
     * @param detailflg �ڍ׃t���O
     */
    public void setDetailflg(String detailflg) {
        this._detailflg = detailflg;
    }

    /**
     * ���ԊJ�n�t���O���擾����
     *
     * @return ���ԊJ�n�t���O
     */
    public String getKikansflg() {
        return _kikansflg;
    }

    /**
     * ���ԊJ�n�t���O��ݒ肷��
     *
     * @param kikansflg ���ԊJ�n�t���O
     */
    public void setKikansflg(String kikansflg) {
        this._kikansflg = kikansflg;
    }

    /**
     * ���ԏI���t���O���擾����
     *
     * @return ���ԏI���t���O
     */
    public String getKikaneflg() {
        return _kikaneflg;
    }

    /**
     * ���ԏI���t���O��ݒ肷��
     *
     * @param kikaneflg ���ԏI���t���O
     */
    public void setKikaneflg(String kikaneflg) {
        this._kikaneflg = kikaneflg;
    }

    /**
     * �_��J�n�N�����t���O���擾����
     *
     * @return �_��J�n�N�����t���O
     */
    public String getContractdateflg() {
        return _contractdateflg;
    }

    /**
     * �_��J�n�N�����t���O��ݒ肷��
     *
     * @param contractdateflg �_��J�n�N�����t���O
     */
    public void setContractdateflg(String contractdateflg) {
        this._contractdateflg = contractdateflg;
    }

    /**
     * �_�����(����)�t���O���擾����
     *
     * @return �_�����(����)�t���O
     */
    public String getContracttermflg() {
        return _contracttermflg;
    }

    /**
     * �_�����(����)�t���O��ݒ肷��
     *
     * @param contracttermflg �_�����(����)�t���O
     */
    public void setContracttermflg(String contracttermflg) {
        this._contracttermflg = contracttermflg;
    }

    /**
     * ������t���O���擾����
     *
     * @return ������t���O
     */
    public String getSeikyuflg() {
        return _seikyuflg;
    }

    /**
     * ������t���O��ݒ肷��
     *
     * @param seikyuflg ������t���O
     */
    public void setSeikyuflg(String seikyuflg) {
        this._seikyuflg = seikyuflg;
    }

    /**
     * ��NO�t���O���擾����
     *
     * @return ��NO�t���O
     */
    public String getOrdernoflg() {
        return _ordernoflg;
    }

    /**
     * ��NO�t���O��ݒ肷��
     *
     * @param ordernoflg ��NO�t���O
     */
    public void setOrdernoflg(String ordernoflg) {
        this._ordernoflg = ordernoflg;
    }

    /**
     * �x����t���O���擾����
     *
     * @return �x����t���O
     */
    public String getPayflg() {
        return _payflg;
    }

    /**
     * �x����t���O��ݒ肷��
     *
     * @param payflg �x����t���O
     */
    public void setPayflg(String payflg) {
        this._payflg = payflg;
    }

    /**
     * �S���҃t���O���擾����
     *
     * @return �S���҃t���O
     */
    public String getUsernameflg() {
        return _usernameflg;
    }

    /**
     * �S���҃t���O��ݒ肷��
     *
     * @param usernameflg �S���҃t���O
     */
    public void setUsernameflg(String usernameflg) {
        this._usernameflg = usernameflg;
    }

    /**
     * �����z�t���O���擾����
     *
     * @return �����z�t���O
     */
    public String getGetmoneyflg() {
        return _getmoneyflg;
    }

    /**
     * �����z�t���O��ݒ肷��
     *
     * @param getmoneyflg �����z�t���O
     */
    public void setGetmoneyflg(String getmoneyflg) {
        this._getmoneyflg = getmoneyflg;
    }

    /**
     * �������z�t���O���擾����
     *
     * @return �������z�t���O
     */
    public String getPaymoneyflg() {
        return _paymoneyflg;
    }

    /**
     * �������z�t���O��ݒ肷��
     *
     * @param paymoneyflg �������z�t���O
     */
    public void setPaymoneyflg(String paymoneyflg) {
        this._paymoneyflg = paymoneyflg;
    }

    /**
     * ���ϋ��z�t���O���擾����
     *
     * @return ���ϋ��z�t���O
     */
    public String getEstmoneyflg() {
        return _estmoneyflg;
    }

    /**
     * ���ϋ��z�t���O��ݒ肷��
     *
     * @param estmoneyflg ���ϋ��z�t���O
     */
    public void setEstmoneyflg(String estmoneyflg) {
        this._estmoneyflg = estmoneyflg;
    }

    /**
     * �������z�t���O���擾����
     *
     * @return �������z�t���O
     */
    public String getClmmoneyflg() {
        return _clmmoneyflg;
    }

    /**
     * �������z�t���O��ݒ肷��
     *
     * @param clmmoneyflg �������z�t���O
     */
    public void setClmmoneyflg(String clmmoneyflg) {
        this._clmmoneyflg = clmmoneyflg;
    }

    /**
     * �x����[�i���t���O���擾����
     *
     * @return �x����[�i���t���O
     */
    public String getDeliverdayflg() {
        return _deliverdayflg;
    }

    /**
     * �x����[�i���t���O��ݒ肷��
     *
     * @param deliverdayflg �x����[�i���t���O
     */
    public void setDeliverdayflg(String deliverdayflg) {
        this._deliverdayflg = deliverdayflg;
    }

    /**
     * �ݒ茎�t���O���擾����
     *
     * @return �ݒ茎�t���O
     */
    public String getSetmonthflg() {
        return _setmonthflg;
    }

    /**
     * �ݒ茎�t���O��ݒ肷��
     *
     * @param setmonthflg �ݒ茎�t���O
     */
    public void setSetmonthflg(String setmonthflg) {
        this._setmonthflg = setmonthflg;
    }

    /**
     * �敪�t���O���擾����
     *
     * @return �敪�t���O
     */
    public String getDivisionflg() {
        return _divisionflg;
    }

    /**
     * �敪�t���O��ݒ肷��
     *
     * @param divisionflg �敪�t���O
     */
    public void setDivisionflg(String divisionflg) {
        this._divisionflg = divisionflg;
    }

    /**
     * �O���[�v�R�[�h�t���O���擾����
     *
     * @return �O���[�v�R�[�h�t���O
     */
    public String getGroupcdflg() {
        return _groupcdflg;
    }

    /**
     * �O���[�v�R�[�h�t���O��ݒ肷��
     *
     * @param groupcdflg �O���[�v�R�[�h�t���O
     */
    public void setGroupcdflg(String groupcdflg) {
        this._groupcdflg = groupcdflg;
    }

    /**
     * �ݒ�ǃi���o�[�t���O���擾����
     *
     * @return �ݒ�ǃi���o�[�t���O
     */
    public String getStkyknoflg() {
        return _stkyknoflg;
    }

    /**
     * �ݒ�ǃi���o�[�t���O��ݒ肷��
     *
     * @param stkyknoflg �ݒ�ǃi���o�[�t���O
     */
    public void setStkyknoflg(String stkyknoflg) {
        this._stkyknoflg = stkyknoflg;
    }

    /**
     * ���͒S���R�[�h�t���O���擾����
     *
     * @return ���͒S���R�[�h�t���O
     */
    public String getInputtntcdflg() {
        return _inputtntcdflg;
    }

    /**
     * ���͒S���R�[�h�t���O��ݒ肷��
     *
     * @param inputtntcdflg ���͒S���R�[�h�t���O
     */
    public void setInputtntcdflg(String inputtntcdflg) {
        this._inputtntcdflg = inputtntcdflg;
    }

    /**
     * ���l�t���O���擾����
     *
     * @return ���l�t���O
     */
    public String getNoteflg() {
        return _noteflg;
    }

    /**
     * ���l�t���O��ݒ肷��
     *
     * @param noteflg ���l�t���O
     */
    public void setNoteflg(String noteflg) {
        this._noteflg = noteflg;
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrtdate() {
        return _crtdate;
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param crtdate �f�[�^�쐬����
     */
    public void setCrtdate(Date crtdate) {
        this._crtdate = crtdate;
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCrtnm() {
        return _crtnm;
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param crtnm �f�[�^�쐬��
     */
    public void setCrtnm(String crtnm) {
        this._crtnm = crtnm;
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCrtapl() {
        return _crtapl;
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param crtapl �쐬�v���O����
     */
    public void setCrtapl(String crtapl) {
        this._crtapl = crtapl;
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCrtid() {
        return _crtid;
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param crtid �쐬�S����ID
     */
    public void setCrtid(String crtid) {
        this._crtid = crtid;
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpddate() {
        return _upddate;
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param upddate �f�[�^�X�V����
     */
    public void setUpddate(Date upddate) {
        this._upddate = upddate;
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUpdnm() {
        return _updnm;
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param updnm �f�[�^�X�V��
     */
    public void setUpdnm(String updnm) {
        this._updnm = updnm;
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param updapl �X�V�v���O����
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUpdid() {
        return _updid;
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param updid �X�V�S����ID
     */
    public void setUpdid(String updid) {
        this._updid = updid;
    }

    /**
     * �����f�[�^�擾�������擾����
     *
     * @return �����f�[�^�擾����
     */
    @XmlElement(required = true, nillable = true)
    public Date getGettime() {
        return _gettime;
    }

    /**
     * �����f�[�^�擾������ݒ肷��
     *
     * @param gettime �����f�[�^�擾����
     */
    public void setGettime(Date gettime) {
        this._gettime = gettime;
    }

    /**
     * �^�C���X�^���v�i����j���擾����
     *
     * @return �^�C���X�^���v�i����j
     */
    @XmlElement(required = true, nillable = true)
    public Date getTimstmpss() {
        return _timstmpss;
    }

    /**
     * �^�C���X�^���v�i����j��ݒ肷��
     *
     * @param timstmpss �^�C���X�^���v�i����j
     */
    public void setTimstmpss(Date timstmpss) {
        this._timstmpss = timstmpss;
    }

    /**
     * �X�V�v���O�����i����j���擾����
     *
     * @return �X�V�v���O�����i����j
     */
    public String getUpdaplss() {
        return _updaplss;
    }

    /**
     * �X�V�v���O�����i����j��ݒ肷��
     *
     * @param updaplss �X�V�v���O�����i����j
     */
    public void setUpdaplss(String updaplss) {
        this._updaplss = updaplss;
    }

    /**
     * �X�V�S����ID�i����j���擾����
     *
     * @return �X�V�S����ID�i����j
     */
    public String getUpdidss() {
        return _updidss;
    }

    /**
     * �X�V�S����ID�i����j��ݒ肷��
     *
     * @param updidss �X�V�S����ID�i����j
     */
    public void setUpdidss(String updidss) {
        this._updidss = updidss;
    }

    /**
     * ���ψČ��Ǘ�NO���擾����
     *
     * @return ���ψČ��Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstseqno() {
        return _estseqno;
    }

    /**
     * ���ψČ��Ǘ�NO��ݒ肷��
     *
     * @param estseqno ���ψČ��Ǘ�NO
     */
    public void setEstseqno(BigDecimal estseqno) {
        this._estseqno = estseqno;
    }

}
