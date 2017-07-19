package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ������ƌ�������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu12ThsKgyCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ������ƃR�[�h */
    private String _thskgycd = null;

    /** �L���I���N���� */
    private String _endymd = null;

    /** �L���J�n�N���� */
    private String _startymd = null;

    /** �\���҃R�[�h */
    private String _snstnt = null;

    /** ������Ɩ��i�J�i�j */
    private String _thskgykn = null;

    /** ������Ɩ��i�����p�J�i�j */
    private String _thskgysrchkn = null;

    /** ������Ɩ��i�p���j */
    private String _thskgyen = null;

    /** ������Ɩ��i�\���p�����j */
    private String _thskgydispkj = null;

    /** ������Ɩ��i���������j */
    private String _thskgylngkj = null;

    /** ��ƋƎ�i�啪�ށj */
    private String _kgygsylcd = null;

    /** ��v�敪 */
    private String _syuyou = null;

    /** �X�֔ԍ� */
    private String _post = null;

    /** �Z�� */
    private String _address = null;

    /** ��Ƒ����R�[�h */
    private String _kgyozok = null;

    /** �l�@�l�敪 */
    private String _kjnhjnkbn = null;

    /** ���R�[�h */
    private String _cntry = null;

    /** ����R�[�h */
    private String _lang = null;

    /** �����N�� */
    private String _chosym = null;

    /** ����Ə��敪 */
    private String _gnskbn = null;

    /** ����Ə��J�n�N���� */
    private String _gnsstaymd = null;

    /** ����Ə��I���N���� */
    private String _gnsendymd = null;

    /** �O���敪 */
    private String _gaisikbn = null;

    /** �P�O���b�l�R�[�h�p�L����R�[�h */
    private String _cm10cdclntcd = null;

    /** �폜�s�t���O */
    private String _delngflg = null;

    /** �`�n�q�̗p��� */
    private String _aorkgy = null;

    /** �t�B�[�̗p��� */
    private String _feekgy = null;

    /** �㗝�X�敪 */
    private String _dtenkbn = null;

    /** �n��d�ʋ敪 */
    private String _areadentsukbn = null;

    /** ���{�� */
    private BigDecimal _sihonkin = null;

    /** �l���ی�敪 */
    private String _kjninfohgkbn = null;

    /** ���Z�� */
    private String _ksnm = null;

    /** �_�~�[�敪 */
    private String _dummykbn = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu12ThsKgyCondition() {
    }

    /**
     * ������ƃR�[�h���擾����
     *
     * @return ������ƃR�[�h
     */
    public String getThskgycd() {
        return _thskgycd;
    }

    /**
     * ������ƃR�[�h��ݒ肷��
     *
     * @param thskgycd ������ƃR�[�h
     */
    public void setThskgycd(String thskgycd) {
        this._thskgycd = thskgycd;
    }

    /**
     * �L���I���N�������擾����
     *
     * @return �L���I���N����
     */
    public String getEndymd() {
        return _endymd;
    }

    /**
     * �L���I���N������ݒ肷��
     *
     * @param endymd �L���I���N����
     */
    public void setEndymd(String endymd) {
        this._endymd = endymd;
    }

    /**
     * �L���J�n�N�������擾����
     *
     * @return �L���J�n�N����
     */
    public String getStartymd() {
        return _startymd;
    }

    /**
     * �L���J�n�N������ݒ肷��
     *
     * @param startymd �L���J�n�N����
     */
    public void setStartymd(String startymd) {
        this._startymd = startymd;
    }

    /**
     * �\���҃R�[�h���擾����
     *
     * @return �\���҃R�[�h
     */
    public String getSnstnt() {
        return _snstnt;
    }

    /**
     * �\���҃R�[�h��ݒ肷��
     *
     * @param snstnt �\���҃R�[�h
     */
    public void setSnstnt(String snstnt) {
        this._snstnt = snstnt;
    }

    /**
     * ������Ɩ��i�J�i�j���擾����
     *
     * @return ������Ɩ��i�J�i�j
     */
    public String getThskgykn() {
        return _thskgykn;
    }

    /**
     * ������Ɩ��i�J�i�j��ݒ肷��
     *
     * @param thskgykn ������Ɩ��i�J�i�j
     */
    public void setThskgykn(String thskgykn) {
        this._thskgykn = thskgykn;
    }

    /**
     * ������Ɩ��i�����p�J�i�j���擾����
     *
     * @return ������Ɩ��i�����p�J�i�j
     */
    public String getThskgysrchkn() {
        return _thskgysrchkn;
    }

    /**
     * ������Ɩ��i�����p�J�i�j��ݒ肷��
     *
     * @param thskgysrchkn ������Ɩ��i�����p�J�i�j
     */
    public void setThskgysrchkn(String thskgysrchkn) {
        this._thskgysrchkn = thskgysrchkn;
    }

    /**
     * ������Ɩ��i�p���j���擾����
     *
     * @return ������Ɩ��i�p���j
     */
    public String getThskgyen() {
        return _thskgyen;
    }

    /**
     * ������Ɩ��i�p���j��ݒ肷��
     *
     * @param thskgyen ������Ɩ��i�p���j
     */
    public void setThskgyen(String thskgyen) {
        this._thskgyen = thskgyen;
    }

    /**
     * ������Ɩ��i�\���p�����j���擾����
     *
     * @return ������Ɩ��i�\���p�����j
     */
    public String getThskgydispkj() {
        return _thskgydispkj;
    }

    /**
     * ������Ɩ��i�\���p�����j��ݒ肷��
     *
     * @param thskgydispkj ������Ɩ��i�\���p�����j
     */
    public void setThskgydispkj(String thskgydispkj) {
        this._thskgydispkj = thskgydispkj;
    }

    /**
     * ������Ɩ��i���������j���擾����
     *
     * @return ������Ɩ��i���������j
     */
    public String getThskgylngkj() {
        return _thskgylngkj;
    }

    /**
     * ������Ɩ��i���������j��ݒ肷��
     *
     * @param thskgylngkj ������Ɩ��i���������j
     */
    public void setThskgylngkj(String thskgylngkj) {
        this._thskgylngkj = thskgylngkj;
    }

    /**
     * ��ƋƎ�i�啪�ށj���擾����
     *
     * @return ��ƋƎ�i�啪�ށj
     */
    public String getKgygsylcd() {
        return _kgygsylcd;
    }

    /**
     * ��ƋƎ�i�啪�ށj��ݒ肷��
     *
     * @param kgygsylcd ��ƋƎ�i�啪�ށj
     */
    public void setKgygsylcd(String kgygsylcd) {
        this._kgygsylcd = kgygsylcd;
    }

    /**
     * ��v�敪���擾����
     *
     * @return ��v�敪
     */
    public String getSyuyou() {
        return _syuyou;
    }

    /**
     * ��v�敪��ݒ肷��
     *
     * @param syuyou ��v�敪
     */
    public void setSyuyou(String syuyou) {
        this._syuyou = syuyou;
    }

    /**
     * �X�֔ԍ����擾����
     *
     * @return �X�֔ԍ�
     */
    public String getPost() {
        return _post;
    }

    /**
     * �X�֔ԍ���ݒ肷��
     *
     * @param post �X�֔ԍ�
     */
    public void setPost(String post) {
        this._post = post;
    }

    /**
     * �Z�����擾����
     *
     * @return �Z��
     */
    public String getAddress() {
        return _address;
    }

    /**
     * �Z����ݒ肷��
     *
     * @param address �Z��
     */
    public void setAddress(String address) {
        this._address = address;
    }

    /**
     * ��Ƒ����R�[�h���擾����
     *
     * @return ��Ƒ����R�[�h
     */
    public String getKgyozok() {
        return _kgyozok;
    }

    /**
     * ��Ƒ����R�[�h��ݒ肷��
     *
     * @param kgyozok ��Ƒ����R�[�h
     */
    public void setKgyozok(String kgyozok) {
        this._kgyozok = kgyozok;
    }

    /**
     * �l�@�l�敪���擾����
     *
     * @return �l�@�l�敪
     */
    public String getKjnhjnkbn() {
        return _kjnhjnkbn;
    }

    /**
     * �l�@�l�敪��ݒ肷��
     *
     * @param kjnhjnkbn �l�@�l�敪
     */
    public void setKjnhjnkbn(String kjnhjnkbn) {
        this._kjnhjnkbn = kjnhjnkbn;
    }

    /**
     * ���R�[�h���擾����
     *
     * @return ���R�[�h
     */
    public String getCntry() {
        return _cntry;
    }

    /**
     * ���R�[�h��ݒ肷��
     *
     * @param cntry ���R�[�h
     */
    public void setCntry(String cntry) {
        this._cntry = cntry;
    }

    /**
     * ����R�[�h���擾����
     *
     * @return ����R�[�h
     */
    public String getLang() {
        return _lang;
    }

    /**
     * ����R�[�h��ݒ肷��
     *
     * @param lang ����R�[�h
     */
    public void setLang(String lang) {
        this._lang = lang;
    }

    /**
     * �����N�����擾����
     *
     * @return �����N��
     */
    public String getChosym() {
        return _chosym;
    }

    /**
     * �����N����ݒ肷��
     *
     * @param chosym �����N��
     */
    public void setChosym(String chosym) {
        this._chosym = chosym;
    }

    /**
     * ����Ə��敪���擾����
     *
     * @return ����Ə��敪
     */
    public String getGnskbn() {
        return _gnskbn;
    }

    /**
     * ����Ə��敪��ݒ肷��
     *
     * @param gnskbn ����Ə��敪
     */
    public void setGnskbn(String gnskbn) {
        this._gnskbn = gnskbn;
    }

    /**
     * ����Ə��J�n�N�������擾����
     *
     * @return ����Ə��J�n�N����
     */
    public String getGnsstaymd() {
        return _gnsstaymd;
    }

    /**
     * ����Ə��J�n�N������ݒ肷��
     *
     * @param gnsstaymd ����Ə��J�n�N����
     */
    public void setGnsstaymd(String gnsstaymd) {
        this._gnsstaymd = gnsstaymd;
    }

    /**
     * ����Ə��I���N�������擾����
     *
     * @return ����Ə��I���N����
     */
    public String getGnsendymd() {
        return _gnsendymd;
    }

    /**
     * ����Ə��I���N������ݒ肷��
     *
     * @param gnsendymd ����Ə��I���N����
     */
    public void setGnsendymd(String gnsendymd) {
        this._gnsendymd = gnsendymd;
    }

    /**
     * �O���敪���擾����
     *
     * @return �O���敪
     */
    public String getGaisikbn() {
        return _gaisikbn;
    }

    /**
     * �O���敪��ݒ肷��
     *
     * @param gaisikbn �O���敪
     */
    public void setGaisikbn(String gaisikbn) {
        this._gaisikbn = gaisikbn;
    }

    /**
     * �P�O���b�l�R�[�h�p�L����R�[�h���擾����
     *
     * @return �P�O���b�l�R�[�h�p�L����R�[�h
     */
    public String getCm10cdclntcd() {
        return _cm10cdclntcd;
    }

    /**
     * �P�O���b�l�R�[�h�p�L����R�[�h��ݒ肷��
     *
     * @param cm10cdclntcd �P�O���b�l�R�[�h�p�L����R�[�h
     */
    public void setCm10cdclntcd(String cm10cdclntcd) {
        this._cm10cdclntcd = cm10cdclntcd;
    }

    /**
     * �폜�s�t���O���擾����
     *
     * @return �폜�s�t���O
     */
    public String getDelngflg() {
        return _delngflg;
    }

    /**
     * �폜�s�t���O��ݒ肷��
     *
     * @param delngflg �폜�s�t���O
     */
    public void setDelngflg(String delngflg) {
        this._delngflg = delngflg;
    }

    /**
     * �`�n�q�̗p��Ƃ��擾����
     *
     * @return �`�n�q�̗p���
     */
    public String getAorkgy() {
        return _aorkgy;
    }

    /**
     * �`�n�q�̗p��Ƃ�ݒ肷��
     *
     * @param aorkgy �`�n�q�̗p���
     */
    public void setAorkgy(String aorkgy) {
        this._aorkgy = aorkgy;
    }

    /**
     * �t�B�[�̗p��Ƃ��擾����
     *
     * @return �t�B�[�̗p���
     */
    public String getFeekgy() {
        return _feekgy;
    }

    /**
     * �t�B�[�̗p��Ƃ�ݒ肷��
     *
     * @param feekgy �t�B�[�̗p���
     */
    public void setFeekgy(String feekgy) {
        this._feekgy = feekgy;
    }

    /**
     * �㗝�X�敪���擾����
     *
     * @return �㗝�X�敪
     */
    public String getDtenkbn() {
        return _dtenkbn;
    }

    /**
     * �㗝�X�敪��ݒ肷��
     *
     * @param dtenkbn �㗝�X�敪
     */
    public void setDtenkbn(String dtenkbn) {
        this._dtenkbn = dtenkbn;
    }

    /**
     * �n��d�ʋ敪���擾����
     *
     * @return �n��d�ʋ敪
     */
    public String getAreadentsukbn() {
        return _areadentsukbn;
    }

    /**
     * �n��d�ʋ敪��ݒ肷��
     *
     * @param areadentsukbn �n��d�ʋ敪
     */
    public void setAreadentsukbn(String areadentsukbn) {
        this._areadentsukbn = areadentsukbn;
    }

    /**
     * ���{�����擾����
     *
     * @return ���{��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSihonkin() {
        return _sihonkin;
    }

    /**
     * ���{����ݒ肷��
     *
     * @param sihonkin ���{��
     */
    public void setSihonkin(BigDecimal sihonkin) {
        this._sihonkin = sihonkin;
    }

    /**
     * �l���ی�敪���擾����
     *
     * @return �l���ی�敪
     */
    public String getKjninfohgkbn() {
        return _kjninfohgkbn;
    }

    /**
     * �l���ی�敪��ݒ肷��
     *
     * @param kjninfohgkbn �l���ی�敪
     */
    public void setKjninfohgkbn(String kjninfohgkbn) {
        this._kjninfohgkbn = kjninfohgkbn;
    }

    /**
     * ���Z�����擾����
     *
     * @return ���Z��
     */
    public String getKsnm() {
        return _ksnm;
    }

    /**
     * ���Z����ݒ肷��
     *
     * @param ksnm ���Z��
     */
    public void setKsnm(String ksnm) {
        this._ksnm = ksnm;
    }

    /**
     * �_�~�[�敪���擾����
     *
     * @return �_�~�[�敪
     */
    public String getDummykbn() {
        return _dummykbn;
    }

    /**
     * �_�~�[�敪��ݒ肷��
     *
     * @param dummykbn �_�~�[�敪
     */
    public void setDummykbn(String dummykbn) {
        this._dummykbn = dummykbn;
    }

}
