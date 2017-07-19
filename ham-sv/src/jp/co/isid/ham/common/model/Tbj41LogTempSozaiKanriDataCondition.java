package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���f�ޓo�^�ύX���O��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj41LogTempSozaiKanriDataCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �n�� */
    private String _nokbn = null;

    /** ��10��CM���� */
    private String _tempcmcd = null;

    /** ����NO */
    private BigDecimal _historyno = null;

    /** 10��CM���� */
    private String _cmcd = null;

    /** �����敪 */
    private String _historykbn = null;

    /** �폜�t���O */
    private String _delflg = null;

    /** �Ԏ�R�[�h */
    private String _dcarcd = null;

    /** �J�e�S�� */
    private String _category = null;

    /** �^�C�g�� */
    private String _title = null;

    /** �b�� */
    private String _second = null;

    /** �Ԏ�S�� */
    private String _syatan = null;

    /** �[�i�� */
    private String _nohin = null;

    /** ��������޸��� */
    private String _product = null;

    /** �����J�n�� */
    private Date _datefrom = null;

    /** �����I���� */
    private Date _dateto = null;

    /** ��ި��g�p���� */
    private Date _mlimit = null;

    /** �����g�p���� */
    private String _klimit = null;

    /** �������F�� */
    private Date _daterecog = null;

    /** ���s�� */
    private Date _dateprt = null;

    /** ���l */
    private String _biko = null;

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
    public Tbj41LogTempSozaiKanriDataCondition() {
    }

    /**
     * �n�����擾����
     *
     * @return �n��
     */
    public String getNokbn() {
        return _nokbn;
    }

    /**
     * �n����ݒ肷��
     *
     * @param nokbn �n��
     */
    public void setNokbn(String nokbn) {
        this._nokbn = nokbn;
    }

    /**
     * ��10��CM���ނ��擾����
     *
     * @return ��10��CM����
     */
    public String getTempcmcd() {
        return _tempcmcd;
    }

    /**
     * ��10��CM���ނ�ݒ肷��
     *
     * @param tempcmcd ��10��CM����
     */
    public void setTempcmcd(String tempcmcd) {
        this._tempcmcd = tempcmcd;
    }

    /**
     * ����NO���擾����
     *
     * @return ����NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHistoryno() {
        return _historyno;
    }

    /**
     * ����NO��ݒ肷��
     *
     * @param historyno ����NO
     */
    public void setHistoryno(BigDecimal historyno) {
        this._historyno = historyno;
    }

    /**
     * 10��CM���ނ��擾����
     *
     * @return 10��CM����
     */
    public String getCmcd() {
        return _cmcd;
    }

    /**
     * 10��CM���ނ�ݒ肷��
     *
     * @param cmcd 10��CM����
     */
    public void setCmcd(String cmcd) {
        this._cmcd = cmcd;
    }

    /**
     * �����敪���擾����
     *
     * @return �����敪
     */
    public String getHistorykbn() {
        return _historykbn;
    }

    /**
     * �����敪��ݒ肷��
     *
     * @param historykbn �����敪
     */
    public void setHistorykbn(String historykbn) {
        this._historykbn = historykbn;
    }

    /**
     * �폜�t���O���擾����
     *
     * @return �폜�t���O
     */
    public String getDelflg() {
        return _delflg;
    }

    /**
     * �폜�t���O��ݒ肷��
     *
     * @param delflg �폜�t���O
     */
    public void setDelflg(String delflg) {
        this._delflg = delflg;
    }

    /**
     * �Ԏ�R�[�h���擾����
     *
     * @return �Ԏ�R�[�h
     */
    public String getDcarcd() {
        return _dcarcd;
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     *
     * @param dcarcd �Ԏ�R�[�h
     */
    public void setDcarcd(String dcarcd) {
        this._dcarcd = dcarcd;
    }

    /**
     * �J�e�S�����擾����
     *
     * @return �J�e�S��
     */
    public String getCategory() {
        return _category;
    }

    /**
     * �J�e�S����ݒ肷��
     *
     * @param category �J�e�S��
     */
    public void setCategory(String category) {
        this._category = category;
    }

    /**
     * �^�C�g�����擾����
     *
     * @return �^�C�g��
     */
    public String getTitle() {
        return _title;
    }

    /**
     * �^�C�g����ݒ肷��
     *
     * @param title �^�C�g��
     */
    public void setTitle(String title) {
        this._title = title;
    }

    /**
     * �b�����擾����
     *
     * @return �b��
     */
    public String getSecond() {
        return _second;
    }

    /**
     * �b����ݒ肷��
     *
     * @param second �b��
     */
    public void setSecond(String second) {
        this._second = second;
    }

    /**
     * �Ԏ�S�����擾����
     *
     * @return �Ԏ�S��
     */
    public String getSyatan() {
        return _syatan;
    }

    /**
     * �Ԏ�S����ݒ肷��
     *
     * @param syatan �Ԏ�S��
     */
    public void setSyatan(String syatan) {
        this._syatan = syatan;
    }

    /**
     * �[�i�����擾����
     *
     * @return �[�i��
     */
    public String getNohin() {
        return _nohin;
    }

    /**
     * �[�i����ݒ肷��
     *
     * @param nohin �[�i��
     */
    public void setNohin(String nohin) {
        this._nohin = nohin;
    }

    /**
     * ��������޸��݂��擾����
     *
     * @return ��������޸���
     */
    public String getProduct() {
        return _product;
    }

    /**
     * ��������޸��݂�ݒ肷��
     *
     * @param product ��������޸���
     */
    public void setProduct(String product) {
        this._product = product;
    }

    /**
     * �����J�n�����擾����
     *
     * @return �����J�n��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDatefrom() {
        return _datefrom;
    }

    /**
     * �����J�n����ݒ肷��
     *
     * @param datefrom �����J�n��
     */
    public void setDatefrom(Date datefrom) {
        this._datefrom = datefrom;
    }

    /**
     * �����I�������擾����
     *
     * @return �����I����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDateto() {
        return _dateto;
    }

    /**
     * �����I������ݒ肷��
     *
     * @param dateto �����I����
     */
    public void setDateto(Date dateto) {
        this._dateto = dateto;
    }

    /**
     * ��ި��g�p�������擾����
     *
     * @return ��ި��g�p����
     */
    @XmlElement(required = true, nillable = true)
    public Date getMlimit() {
        return _mlimit;
    }

    /**
     * ��ި��g�p������ݒ肷��
     *
     * @param mlimit ��ި��g�p����
     */
    public void setMlimit(Date mlimit) {
        this._mlimit = mlimit;
    }

    /**
     * �����g�p�������擾����
     *
     * @return �����g�p����
     */
    public String getKlimit() {
        return _klimit;
    }

    /**
     * �����g�p������ݒ肷��
     *
     * @param klimit �����g�p����
     */
    public void setKlimit(String klimit) {
        this._klimit = klimit;
    }

    /**
     * �������F�����擾����
     *
     * @return �������F��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDaterecog() {
        return _daterecog;
    }

    /**
     * �������F����ݒ肷��
     *
     * @param daterecog �������F��
     */
    public void setDaterecog(Date daterecog) {
        this._daterecog = daterecog;
    }

    /**
     * ���s�����擾����
     *
     * @return ���s��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDateprt() {
        return _dateprt;
    }

    /**
     * ���s����ݒ肷��
     *
     * @param dateprt ���s��
     */
    public void setDateprt(Date dateprt) {
        this._dateprt = dateprt;
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getBiko() {
        return _biko;
    }

    /**
     * ���l��ݒ肷��
     *
     * @param biko ���l
     */
    public void setBiko(String biko) {
        this._biko = biko;
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
