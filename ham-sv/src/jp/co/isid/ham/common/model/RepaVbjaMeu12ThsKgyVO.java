package jp.co.isid.ham.common.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu12ThsKgy;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �������VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu12ThsKgyVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu12ThsKgyVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RepaVbjaMeu12ThsKgyVO();
    }

    /**
     * ������ƃR�[�h���擾����
     *
     * @return ������ƃR�[�h
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYCD);
    }

    /**
     * ������ƃR�[�h��ݒ肷��
     *
     * @param val ������ƃR�[�h
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYCD, val);
    }

    /**
     * �L���I���N�������擾����
     *
     * @return �L���I���N����
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu12ThsKgy.ENDYMD);
    }

    /**
     * �L���I���N������ݒ肷��
     *
     * @param val �L���I���N����
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu12ThsKgy.ENDYMD, val);
    }

    /**
     * �L���J�n�N�������擾����
     *
     * @return �L���J�n�N����
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu12ThsKgy.STARTYMD);
    }

    /**
     * �L���J�n�N������ݒ肷��
     *
     * @param val �L���J�n�N����
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu12ThsKgy.STARTYMD, val);
    }

    /**
     * �\���҃R�[�h���擾����
     *
     * @return �\���҃R�[�h
     */
    public String getSNSTNT() {
        return (String) get(RepaVbjaMeu12ThsKgy.SNSTNT);
    }

    /**
     * �\���҃R�[�h��ݒ肷��
     *
     * @param val �\���҃R�[�h
     */
    public void setSNSTNT(String val) {
        set(RepaVbjaMeu12ThsKgy.SNSTNT, val);
    }

    /**
     * ������Ɩ��i�J�i�j���擾����
     *
     * @return ������Ɩ��i�J�i�j
     */
    public String getTHSKGYKN() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYKN);
    }

    /**
     * ������Ɩ��i�J�i�j��ݒ肷��
     *
     * @param val ������Ɩ��i�J�i�j
     */
    public void setTHSKGYKN(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYKN, val);
    }

    /**
     * ������Ɩ��i�����p�J�i�j���擾����
     *
     * @return ������Ɩ��i�����p�J�i�j
     */
    public String getTHSKGYSRCHKN() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYSRCHKN);
    }

    /**
     * ������Ɩ��i�����p�J�i�j��ݒ肷��
     *
     * @param val ������Ɩ��i�����p�J�i�j
     */
    public void setTHSKGYSRCHKN(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYSRCHKN, val);
    }

    /**
     * ������Ɩ��i�p���j���擾����
     *
     * @return ������Ɩ��i�p���j
     */
    public String getTHSKGYEN() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYEN);
    }

    /**
     * ������Ɩ��i�p���j��ݒ肷��
     *
     * @param val ������Ɩ��i�p���j
     */
    public void setTHSKGYEN(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYEN, val);
    }

    /**
     * ������Ɩ��i�\���p�����j���擾����
     *
     * @return ������Ɩ��i�\���p�����j
     */
    public String getTHSKGYDISPKJ() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYDISPKJ);
    }

    /**
     * ������Ɩ��i�\���p�����j��ݒ肷��
     *
     * @param val ������Ɩ��i�\���p�����j
     */
    public void setTHSKGYDISPKJ(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYDISPKJ, val);
    }

    /**
     * ������Ɩ��i���������j���擾����
     *
     * @return ������Ɩ��i���������j
     */
    public String getTHSKGYLNGKJ() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYLNGKJ);
    }

    /**
     * ������Ɩ��i���������j��ݒ肷��
     *
     * @param val ������Ɩ��i���������j
     */
    public void setTHSKGYLNGKJ(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYLNGKJ, val);
    }

    /**
     * ��ƋƎ�i�啪�ށj���擾����
     *
     * @return ��ƋƎ�i�啪�ށj
     */
    public String getKGYGSYLCD() {
        return (String) get(RepaVbjaMeu12ThsKgy.KGYGSYLCD);
    }

    /**
     * ��ƋƎ�i�啪�ށj��ݒ肷��
     *
     * @param val ��ƋƎ�i�啪�ށj
     */
    public void setKGYGSYLCD(String val) {
        set(RepaVbjaMeu12ThsKgy.KGYGSYLCD, val);
    }

    /**
     * ��v�敪���擾����
     *
     * @return ��v�敪
     */
    public String getSYUYOU() {
        return (String) get(RepaVbjaMeu12ThsKgy.SYUYOU);
    }

    /**
     * ��v�敪��ݒ肷��
     *
     * @param val ��v�敪
     */
    public void setSYUYOU(String val) {
        set(RepaVbjaMeu12ThsKgy.SYUYOU, val);
    }

    /**
     * �X�֔ԍ����擾����
     *
     * @return �X�֔ԍ�
     */
    public String getPOST() {
        return (String) get(RepaVbjaMeu12ThsKgy.POST);
    }

    /**
     * �X�֔ԍ���ݒ肷��
     *
     * @param val �X�֔ԍ�
     */
    public void setPOST(String val) {
        set(RepaVbjaMeu12ThsKgy.POST, val);
    }

    /**
     * �Z�����擾����
     *
     * @return �Z��
     */
    public String getADDRESS() {
        return (String) get(RepaVbjaMeu12ThsKgy.ADDRESS);
    }

    /**
     * �Z����ݒ肷��
     *
     * @param val �Z��
     */
    public void setADDRESS(String val) {
        set(RepaVbjaMeu12ThsKgy.ADDRESS, val);
    }

    /**
     * ��Ƒ����R�[�h���擾����
     *
     * @return ��Ƒ����R�[�h
     */
    public String getKGYOZOK() {
        return (String) get(RepaVbjaMeu12ThsKgy.KGYOZOK);
    }

    /**
     * ��Ƒ����R�[�h��ݒ肷��
     *
     * @param val ��Ƒ����R�[�h
     */
    public void setKGYOZOK(String val) {
        set(RepaVbjaMeu12ThsKgy.KGYOZOK, val);
    }

    /**
     * �l�@�l�敪���擾����
     *
     * @return �l�@�l�敪
     */
    public String getKJNHJNKBN() {
        return (String) get(RepaVbjaMeu12ThsKgy.KJNHJNKBN);
    }

    /**
     * �l�@�l�敪��ݒ肷��
     *
     * @param val �l�@�l�敪
     */
    public void setKJNHJNKBN(String val) {
        set(RepaVbjaMeu12ThsKgy.KJNHJNKBN, val);
    }

    /**
     * ���R�[�h���擾����
     *
     * @return ���R�[�h
     */
    public String getCNTRY() {
        return (String) get(RepaVbjaMeu12ThsKgy.CNTRY);
    }

    /**
     * ���R�[�h��ݒ肷��
     *
     * @param val ���R�[�h
     */
    public void setCNTRY(String val) {
        set(RepaVbjaMeu12ThsKgy.CNTRY, val);
    }

    /**
     * ����R�[�h���擾����
     *
     * @return ����R�[�h
     */
    public String getLANG() {
        return (String) get(RepaVbjaMeu12ThsKgy.LANG);
    }

    /**
     * ����R�[�h��ݒ肷��
     *
     * @param val ����R�[�h
     */
    public void setLANG(String val) {
        set(RepaVbjaMeu12ThsKgy.LANG, val);
    }

    /**
     * �����N�����擾����
     *
     * @return �����N��
     */
    public String getCHOSYM() {
        return (String) get(RepaVbjaMeu12ThsKgy.CHOSYM);
    }

    /**
     * �����N����ݒ肷��
     *
     * @param val �����N��
     */
    public void setCHOSYM(String val) {
        set(RepaVbjaMeu12ThsKgy.CHOSYM, val);
    }

    /**
     * ����Ə��敪���擾����
     *
     * @return ����Ə��敪
     */
    public String getGNSKBN() {
        return (String) get(RepaVbjaMeu12ThsKgy.GNSKBN);
    }

    /**
     * ����Ə��敪��ݒ肷��
     *
     * @param val ����Ə��敪
     */
    public void setGNSKBN(String val) {
        set(RepaVbjaMeu12ThsKgy.GNSKBN, val);
    }

    /**
     * ����Ə��J�n�N�������擾����
     *
     * @return ����Ə��J�n�N����
     */
    public String getGNSSTAYMD() {
        return (String) get(RepaVbjaMeu12ThsKgy.GNSSTAYMD);
    }

    /**
     * ����Ə��J�n�N������ݒ肷��
     *
     * @param val ����Ə��J�n�N����
     */
    public void setGNSSTAYMD(String val) {
        set(RepaVbjaMeu12ThsKgy.GNSSTAYMD, val);
    }

    /**
     * ����Ə��I���N�������擾����
     *
     * @return ����Ə��I���N����
     */
    public String getGNSENDYMD() {
        return (String) get(RepaVbjaMeu12ThsKgy.GNSENDYMD);
    }

    /**
     * ����Ə��I���N������ݒ肷��
     *
     * @param val ����Ə��I���N����
     */
    public void setGNSENDYMD(String val) {
        set(RepaVbjaMeu12ThsKgy.GNSENDYMD, val);
    }

    /**
     * �O���敪���擾����
     *
     * @return �O���敪
     */
    public String getGAISIKBN() {
        return (String) get(RepaVbjaMeu12ThsKgy.GAISIKBN);
    }

    /**
     * �O���敪��ݒ肷��
     *
     * @param val �O���敪
     */
    public void setGAISIKBN(String val) {
        set(RepaVbjaMeu12ThsKgy.GAISIKBN, val);
    }

    /**
     * �P�O���b�l�R�[�h�p�L����R�[�h���擾����
     *
     * @return �P�O���b�l�R�[�h�p�L����R�[�h
     */
    public String getCM10CDCLNTCD() {
        return (String) get(RepaVbjaMeu12ThsKgy.CM10CDCLNTCD);
    }

    /**
     * �P�O���b�l�R�[�h�p�L����R�[�h��ݒ肷��
     *
     * @param val �P�O���b�l�R�[�h�p�L����R�[�h
     */
    public void setCM10CDCLNTCD(String val) {
        set(RepaVbjaMeu12ThsKgy.CM10CDCLNTCD, val);
    }

    /**
     * �폜�s�t���O���擾����
     *
     * @return �폜�s�t���O
     */
    public String getDELNGFLG() {
        return (String) get(RepaVbjaMeu12ThsKgy.DELNGFLG);
    }

    /**
     * �폜�s�t���O��ݒ肷��
     *
     * @param val �폜�s�t���O
     */
    public void setDELNGFLG(String val) {
        set(RepaVbjaMeu12ThsKgy.DELNGFLG, val);
    }

    /**
     * �`�n�q�̗p��Ƃ��擾����
     *
     * @return �`�n�q�̗p���
     */
    public String getAORKGY() {
        return (String) get(RepaVbjaMeu12ThsKgy.AORKGY);
    }

    /**
     * �`�n�q�̗p��Ƃ�ݒ肷��
     *
     * @param val �`�n�q�̗p���
     */
    public void setAORKGY(String val) {
        set(RepaVbjaMeu12ThsKgy.AORKGY, val);
    }

    /**
     * �t�B�[�̗p��Ƃ��擾����
     *
     * @return �t�B�[�̗p���
     */
    public String getFEEKGY() {
        return (String) get(RepaVbjaMeu12ThsKgy.FEEKGY);
    }

    /**
     * �t�B�[�̗p��Ƃ�ݒ肷��
     *
     * @param val �t�B�[�̗p���
     */
    public void setFEEKGY(String val) {
        set(RepaVbjaMeu12ThsKgy.FEEKGY, val);
    }

    /**
     * �㗝�X�敪���擾����
     *
     * @return �㗝�X�敪
     */
    public String getDTENKBN() {
        return (String) get(RepaVbjaMeu12ThsKgy.DTENKBN);
    }

    /**
     * �㗝�X�敪��ݒ肷��
     *
     * @param val �㗝�X�敪
     */
    public void setDTENKBN(String val) {
        set(RepaVbjaMeu12ThsKgy.DTENKBN, val);
    }

    /**
     * �n��d�ʋ敪���擾����
     *
     * @return �n��d�ʋ敪
     */
    public String getAREADENTSUKBN() {
        return (String) get(RepaVbjaMeu12ThsKgy.AREADENTSUKBN);
    }

    /**
     * �n��d�ʋ敪��ݒ肷��
     *
     * @param val �n��d�ʋ敪
     */
    public void setAREADENTSUKBN(String val) {
        set(RepaVbjaMeu12ThsKgy.AREADENTSUKBN, val);
    }

    /**
     * ���{�����擾����
     *
     * @return ���{��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSIHONKIN() {
        return (BigDecimal) get(RepaVbjaMeu12ThsKgy.SIHONKIN);
    }

    /**
     * ���{����ݒ肷��
     *
     * @param val ���{��
     */
    public void setSIHONKIN(BigDecimal val) {
        set(RepaVbjaMeu12ThsKgy.SIHONKIN, val);
    }

    /**
     * �l���ی�敪���擾����
     *
     * @return �l���ی�敪
     */
    public String getKJNINFOHGKBN() {
        return (String) get(RepaVbjaMeu12ThsKgy.KJNINFOHGKBN);
    }

    /**
     * �l���ی�敪��ݒ肷��
     *
     * @param val �l���ی�敪
     */
    public void setKJNINFOHGKBN(String val) {
        set(RepaVbjaMeu12ThsKgy.KJNINFOHGKBN, val);
    }

    /**
     * ���Z�����擾����
     *
     * @return ���Z��
     */
    public String getKSNM() {
        return (String) get(RepaVbjaMeu12ThsKgy.KSNM);
    }

    /**
     * ���Z����ݒ肷��
     *
     * @param val ���Z��
     */
    public void setKSNM(String val) {
        set(RepaVbjaMeu12ThsKgy.KSNM, val);
    }

    /**
     * �_�~�[�敪���擾����
     *
     * @return �_�~�[�敪
     */
    public String getDUMMYKBN() {
        return (String) get(RepaVbjaMeu12ThsKgy.DUMMYKBN);
    }

    /**
     * �_�~�[�敪��ݒ肷��
     *
     * @param val �_�~�[�敪
     */
    public void setDUMMYKBN(String val) {
        set(RepaVbjaMeu12ThsKgy.DUMMYKBN, val);
    }

}
