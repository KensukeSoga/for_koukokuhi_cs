package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �}�̏󋵊Ǘ���������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj01MediaPlanCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �L�����y�[���R�[�h */
    private String _campcd = null;

    /** �}�̊Ǘ�No */
    private BigDecimal _mediaplanno = null;

    /** �o�e�\��N�� */
    private Date _yoteiym = null;

    /** �n��R�[�h */
    private String _keirestucd = null;

    /** �d�ʎԎ�R�[�h */
    private String _dcarcd = null;

    /** �}�̃R�[�h */
    private String _mediacd = null;

    /** ��p�v��No */
    private String _hiyouno = null;

    /** �㗝�X�� */
    private String _agency = null;

    /** �L������ */
    private String _kenmei = null;

    /** ���L���� */
    private String _memo = null;

    /** �t�F�C�Y */
    private BigDecimal _phase = null;

    /** �� */
    private String _term = null;

    /** �\����ԊJ�n */
    private Date _kikanfrom = null;

    /** �\����ԏI�� */
    private Date _kikanto = null;

    /** �g�l���F */
    private String _hmok = null;

    /** �}�̔��� */
    private String _buyerok = null;

    /** �\�Z���z */
    private BigDecimal _budget = null;

    /** �\�Z���z(�V) */
    private BigDecimal _budgethm = null;

    /** ���{���z */
    private BigDecimal _actual = null;

    /** ���{���z(�V) */
    private BigDecimal _actualhm = null;

    /** �������z */
    private BigDecimal _adjustment = null;

    /** �\�����z */
    private BigDecimal _difamt = null;

    /** �\�����z(�V) */
    private BigDecimal _difamthm = null;

    /** �\�Z�o�^�t���O */
    private String _budgetupdflg = null;

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

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj01MediaPlanCondition() {
    }

    /**
     * �L�����y�[���R�[�h���擾����
     *
     * @return �L�����y�[���R�[�h
     */
    public String getCampcd() {
        return _campcd;
    }

    /**
     * �L�����y�[���R�[�h��ݒ肷��
     *
     * @param campcd �L�����y�[���R�[�h
     */
    public void setCampcd(String campcd) {
        this._campcd = campcd;
    }

    /**
     * �}�̊Ǘ�No���擾����
     *
     * @return �}�̊Ǘ�No
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMediaplanno() {
        return _mediaplanno;
    }

    /**
     * �}�̊Ǘ�No��ݒ肷��
     *
     * @param mediaplanno �}�̊Ǘ�No
     */
    public void setMediaplanno(BigDecimal mediaplanno) {
        this._mediaplanno = mediaplanno;
    }

    /**
     * �o�e�\��N�����擾����
     *
     * @return �o�e�\��N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getYoteiym() {
        return _yoteiym;
    }

    /**
     * �o�e�\��N����ݒ肷��
     *
     * @param yoteiym �o�e�\��N��
     */
    public void setYoteiym(Date yoteiym) {
        this._yoteiym = yoteiym;
    }

    /**
     * �n��R�[�h���擾����
     *
     * @return �n��R�[�h
     */
    public String getKeirestucd() {
        return _keirestucd;
    }

    /**
     * �n��R�[�h��ݒ肷��
     *
     * @param keirestucd �n��R�[�h
     */
    public void setKeirestucd(String keirestucd) {
        this._keirestucd = keirestucd;
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
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMediacd() {
        return _mediacd;
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param mediacd �}�̃R�[�h
     */
    public void setMediacd(String mediacd) {
        this._mediacd = mediacd;
    }

    /**
     * ��p�v��No���擾����
     *
     * @return ��p�v��No
     */
    public String getHiyouno() {
        return _hiyouno;
    }

    /**
     * ��p�v��No��ݒ肷��
     *
     * @param hiyouno ��p�v��No
     */
    public void setHiyouno(String hiyouno) {
        this._hiyouno = hiyouno;
    }

    /**
     * �㗝�X�����擾����
     *
     * @return �㗝�X��
     */
    public String getAgency() {
        return _agency;
    }

    /**
     * �㗝�X����ݒ肷��
     *
     * @param agency �㗝�X��
     */
    public void setAgency(String agency) {
        this._agency = agency;
    }

    /**
     * �L���������擾����
     *
     * @return �L������
     */
    public String getKenmei() {
        return _kenmei;
    }

    /**
     * �L��������ݒ肷��
     *
     * @param kenmei �L������
     */
    public void setKenmei(String kenmei) {
        this._kenmei = kenmei;
    }

    /**
     * ���L�������擾����
     *
     * @return ���L����
     */
    public String getMemo() {
        return _memo;
    }

    /**
     * ���L������ݒ肷��
     *
     * @param memo ���L����
     */
    public void setMemo(String memo) {
        this._memo = memo;
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
     * �����擾����
     *
     * @return ��
     */
    public String getTerm() {
        return _term;
    }

    /**
     * ����ݒ肷��
     *
     * @param term ��
     */
    public void setTerm(String term) {
        this._term = term;
    }

    /**
     * �\����ԊJ�n���擾����
     *
     * @return �\����ԊJ�n
     */
    @XmlElement(required = true, nillable = true)
    public Date getKikanfrom() {
        return _kikanfrom;
    }

    /**
     * �\����ԊJ�n��ݒ肷��
     *
     * @param kikanfrom �\����ԊJ�n
     */
    public void setKikanfrom(Date kikanfrom) {
        this._kikanfrom = kikanfrom;
    }

    /**
     * �\����ԏI�����擾����
     *
     * @return �\����ԏI��
     */
    @XmlElement(required = true, nillable = true)
    public Date getKikanto() {
        return _kikanto;
    }

    /**
     * �\����ԏI����ݒ肷��
     *
     * @param kikanto �\����ԏI��
     */
    public void setKikanto(Date kikanto) {
        this._kikanto = kikanto;
    }

    /**
     * �g�l���F���擾����
     *
     * @return �g�l���F
     */
    public String getHmok() {
        return _hmok;
    }

    /**
     * �g�l���F��ݒ肷��
     *
     * @param hmok �g�l���F
     */
    public void setHmok(String hmok) {
        this._hmok = hmok;
    }

    /**
     * �}�̔������擾����
     *
     * @return �}�̔���
     */
    public String getBuyerok() {
        return _buyerok;
    }

    /**
     * �}�̔�����ݒ肷��
     *
     * @param buyerok �}�̔���
     */
    public void setBuyerok(String buyerok) {
        this._buyerok = buyerok;
    }

    /**
     * �\�Z���z���擾����
     *
     * @return �\�Z���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBudget() {
        return _budget;
    }

    /**
     * �\�Z���z��ݒ肷��
     *
     * @param budget �\�Z���z
     */
    public void setBudget(BigDecimal budget) {
        this._budget = budget;
    }

    /**
     * �\�Z���z(�V)���擾����
     *
     * @return �\�Z���z(�V)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBudgethm() {
        return _budgethm;
    }

    /**
     * �\�Z���z(�V)��ݒ肷��
     *
     * @param budgethm �\�Z���z(�V)
     */
    public void setBudgethm(BigDecimal budgethm) {
        this._budgethm = budgethm;
    }

    /**
     * ���{���z���擾����
     *
     * @return ���{���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getActual() {
        return _actual;
    }

    /**
     * ���{���z��ݒ肷��
     *
     * @param actual ���{���z
     */
    public void setActual(BigDecimal actual) {
        this._actual = actual;
    }

    /**
     * ���{���z(�V)���擾����
     *
     * @return ���{���z(�V)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getActualhm() {
        return _actualhm;
    }

    /**
     * ���{���z(�V)��ݒ肷��
     *
     * @param actualhm ���{���z(�V)
     */
    public void setActualhm(BigDecimal actualhm) {
        this._actualhm = actualhm;
    }

    /**
     * �������z���擾����
     *
     * @return �������z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getAdjustment() {
        return _adjustment;
    }

    /**
     * �������z��ݒ肷��
     *
     * @param adjustment �������z
     */
    public void setAdjustment(BigDecimal adjustment) {
        this._adjustment = adjustment;
    }

    /**
     * �\�����z���擾����
     *
     * @return �\�����z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDifamt() {
        return _difamt;
    }

    /**
     * �\�����z��ݒ肷��
     *
     * @param difamt �\�����z
     */
    public void setDifamt(BigDecimal difamt) {
        this._difamt = difamt;
    }

    /**
     * �\�����z(�V)���擾����
     *
     * @return �\�����z(�V)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDifamthm() {
        return _difamthm;
    }

    /**
     * �\�����z(�V)��ݒ肷��
     *
     * @param difamthm �\�����z(�V)
     */
    public void setDifamthm(BigDecimal difamthm) {
        this._difamthm = difamthm;
    }

    /**
     * �\�Z�o�^�t���O���擾����
     *
     * @return �\�Z�o�^�t���O
     */
    public String getBudgetupdflg() {
        return _budgetupdflg;
    }

    /**
     * �\�Z�o�^�t���O��ݒ肷��
     *
     * @param budgetupdflg �\�Z�o�^�t���O
     */
    public void setBudgetupdflg(String budgetupdflg) {
        this._budgetupdflg = budgetupdflg;
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

}
