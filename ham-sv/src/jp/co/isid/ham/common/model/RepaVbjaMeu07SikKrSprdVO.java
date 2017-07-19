package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �o���g�D�W�J�e�[�u��VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu07SikKrSprdVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu07SikKrSprdVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RepaVbjaMeu07SikKrSprdVO();
    }

    /**
     * �g�D�R�[�h���擾����
     *
     * @return �g�D�R�[�h
     */
    public String getSIKCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCD);
    }

    /**
     * �g�D�R�[�h��ݒ肷��
     *
     * @param val �g�D�R�[�h
     */
    public void setSIKCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCD, val);
    }

    /**
     * �L���I���N�������擾����
     *
     * @return �L���I���N����
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.ENDYMD);
    }

    /**
     * �L���I���N������ݒ肷��
     *
     * @param val �L���I���N����
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu07SikKrSprd.ENDYMD, val);
    }

    /**
     * �L���J�n�N�������擾����
     *
     * @return �L���J�n�N����
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.STARTYMD);
    }

    /**
     * �L���J�n�N������ݒ肷��
     *
     * @param val �L���J�n�N����
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu07SikKrSprd.STARTYMD, val);
    }

    /**
     * �o���K�w�R�[�h���擾����
     *
     * @return �o���K�w�R�[�h
     */
    public String getKRIKAISOCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KRIKAISOCD);
    }

    /**
     * �o���K�w�R�[�h��ݒ肷��
     *
     * @param val �o���K�w�R�[�h
     */
    public void setKRIKAISOCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.KRIKAISOCD, val);
    }

    /**
     * �o����ʑg�D�R�[�h���擾����
     *
     * @return �o����ʑg�D�R�[�h
     */
    public String getKRIJSIKCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KRIJSIKCD);
    }

    /**
     * �o����ʑg�D�R�[�h��ݒ肷��
     *
     * @param val �o����ʑg�D�R�[�h
     */
    public void setKRIJSIKCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.KRIJSIKCD, val);
    }

    /**
     * �����敪���擾����
     *
     * @return �����敪
     */
    public String getCKATUKBN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.CKATUKBN);
    }

    /**
     * �����敪��ݒ肷��
     *
     * @param val �����敪
     */
    public void setCKATUKBN(String val) {
        set(RepaVbjaMeu07SikKrSprd.CKATUKBN, val);
    }

    /**
     * �󒍓o�^�敪���擾����
     *
     * @return �󒍓o�^�敪
     */
    public String getJYTRKKBN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.JYTRKKBN);
    }

    /**
     * �󒍓o�^�敪��ݒ肷��
     *
     * @param val �󒍓o�^�敪
     */
    public void setJYTRKKBN(String val) {
        set(RepaVbjaMeu07SikKrSprd.JYTRKKBN, val);
    }

    /**
     * �����o�^�敪���擾����
     *
     * @return �����o�^�敪
     */
    public String getODRTRKKBN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.ODRTRKKBN);
    }

    /**
     * �����o�^�敪��ݒ肷��
     *
     * @param val �����o�^�敪
     */
    public void setODRTRKKBN(String val) {
        set(RepaVbjaMeu07SikKrSprd.ODRTRKKBN, val);
    }

    /**
     * �Ǘ�������擾����
     *
     * @return �Ǘ�����
     */
    public String getKNRIBMON() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KNRIBMON);
    }

    /**
     * �Ǘ������ݒ肷��
     *
     * @param val �Ǘ�����
     */
    public void setKNRIBMON(String val) {
        set(RepaVbjaMeu07SikKrSprd.KNRIBMON, val);
    }

    /**
     * ��Ў����R�[�h���擾����
     *
     * @return ��Ў����R�[�h
     */
    public String getKSHATHSCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KSHATHSCD);
    }

    /**
     * ��Ў����R�[�h��ݒ肷��
     *
     * @param val ��Ў����R�[�h
     */
    public void setKSHATHSCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.KSHATHSCD, val);
    }

    /**
     * ��Ў����r�d�p�m�n���擾����
     *
     * @return ��Ў����r�d�p�m�n
     */
    public String getKSHATHSSEQNO() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KSHATHSSEQNO);
    }

    /**
     * ��Ў����r�d�p�m�n��ݒ肷��
     *
     * @param val ��Ў����r�d�p�m�n
     */
    public void setKSHATHSSEQNO(String val) {
        set(RepaVbjaMeu07SikKrSprd.KSHATHSSEQNO, val);
    }

    /**
     * �������R�[�h���擾����
     *
     * @return �������R�[�h
     */
    public String getKYUTRCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KYUTRCD);
    }

    /**
     * �������R�[�h��ݒ肷��
     *
     * @param val �������R�[�h
     */
    public void setKYUTRCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.KYUTRCD, val);
    }

    /**
     * �}���敪���擾����
     *
     * @return �}���敪
     */
    public String getBCKKBN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BCKKBN);
    }

    /**
     * �}���敪��ݒ肷��
     *
     * @param val �}���敪
     */
    public void setBCKKBN(String val) {
        set(RepaVbjaMeu07SikKrSprd.BCKKBN, val);
    }

    /**
     * �c�Ə��R�[�h���擾����
     *
     * @return �c�Ə��R�[�h
     */
    public String getEGSYOCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.EGSYOCD);
    }

    /**
     * �c�Ə��R�[�h��ݒ肷��
     *
     * @param val �c�Ə��R�[�h
     */
    public void setEGSYOCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.EGSYOCD, val);
    }

    /**
     * �\�������擾����
     *
     * @return �\����
     */
    public String getSHOWNO() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SHOWNO);
    }

    /**
     * �\������ݒ肷��
     *
     * @param val �\����
     */
    public void setSHOWNO(String val) {
        set(RepaVbjaMeu07SikKrSprd.SHOWNO, val);
    }

    /**
     * ��ʑg�D���\�������擾����
     *
     * @return ��ʑg�D���\����
     */
    public String getJSIKHYOJIJUN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.JSIKHYOJIJUN);
    }

    /**
     * ��ʑg�D���\������ݒ肷��
     *
     * @param val ��ʑg�D���\����
     */
    public void setJSIKHYOJIJUN(String val) {
        set(RepaVbjaMeu07SikKrSprd.JSIKHYOJIJUN, val);
    }

    /**
     * �\�����i�J�i�j���擾����
     *
     * @return �\�����i�J�i�j
     */
    public String getHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HYOJIKN);
    }

    /**
     * �\�����i�J�i�j��ݒ肷��
     *
     * @param val �\�����i�J�i�j
     */
    public void setHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.HYOJIKN, val);
    }

    /**
     * �\�����i�����j���擾����
     *
     * @return �\�����i�����j
     */
    public String getHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HYOJIKJ);
    }

    /**
     * �\�����i�����j��ݒ肷��
     *
     * @param val �\�����i�����j
     */
    public void setHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.HYOJIKJ, val);
    }

    /**
     * �\�����̂��擾����
     *
     * @return �\������
     */
    public String getHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HYOJIRYAKU);
    }

    /**
     * �\�����̂�ݒ肷��
     *
     * @param val �\������
     */
    public void setHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.HYOJIRYAKU, val);
    }

    /**
     * �\�����i�p���j���擾����
     *
     * @return �\�����i�p���j
     */
    public String getHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HYOJIEN);
    }

    /**
     * �\�����i�p���j��ݒ肷��
     *
     * @param val �\�����i�p���j
     */
    public void setHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.HYOJIEN, val);
    }

    /**
     * ��Ў��ʃR�[�h���擾����
     *
     * @return ��Ў��ʃR�[�h
     */
    public String getKSHASKBTUCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KSHASKBTUCD);
    }

    /**
     * ��Ў��ʃR�[�h��ݒ肷��
     *
     * @param val ��Ў��ʃR�[�h
     */
    public void setKSHASKBTUCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.KSHASKBTUCD, val);
    }

    /**
     * ���o�̓R�[�h���擾����
     *
     * @return ���o�̓R�[�h
     */
    public String getIOCD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.IOCD);
    }

    /**
     * ���o�̓R�[�h��ݒ肷��
     *
     * @param val ���o�̓R�[�h
     */
    public void setIOCD(String val) {
        set(RepaVbjaMeu07SikKrSprd.IOCD, val);
    }

    /**
     * ����p�r�R�[�h���擾����
     *
     * @return ����p�r�R�[�h
     */
    public String getSPUSECD() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SPUSECD);
    }

    /**
     * ����p�r�R�[�h��ݒ肷��
     *
     * @param val ����p�r�R�[�h
     */
    public void setSPUSECD(String val) {
        set(RepaVbjaMeu07SikKrSprd.SPUSECD, val);
    }

    /**
     * �g�D�R�[�h�i�{���j���擾����
     *
     * @return �g�D�R�[�h�i�{���j
     */
    public String getSIKCDHONB() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDHONB);
    }

    /**
     * �g�D�R�[�h�i�{���j��ݒ肷��
     *
     * @param val �g�D�R�[�h�i�{���j
     */
    public void setSIKCDHONB(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDHONB, val);
    }

    /**
     * �{���\�����i�J�i�j���擾����
     *
     * @return �{���\�����i�J�i�j
     */
    public String getHONBHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HONBHYOJIKN);
    }

    /**
     * �{���\�����i�J�i�j��ݒ肷��
     *
     * @param val �{���\�����i�J�i�j
     */
    public void setHONBHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.HONBHYOJIKN, val);
    }

    /**
     * �{���\�����i�����j���擾����
     *
     * @return �{���\�����i�����j
     */
    public String getHONBHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HONBHYOJIKJ);
    }

    /**
     * �{���\�����i�����j��ݒ肷��
     *
     * @param val �{���\�����i�����j
     */
    public void setHONBHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.HONBHYOJIKJ, val);
    }

    /**
     * �{���\�����̂��擾����
     *
     * @return �{���\������
     */
    public String getHONBHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HONBHYOJIRYAKU);
    }

    /**
     * �{���\�����̂�ݒ肷��
     *
     * @param val �{���\������
     */
    public void setHONBHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.HONBHYOJIRYAKU, val);
    }

    /**
     * �{���\�����i�p���j���擾����
     *
     * @return �{���\�����i�p���j
     */
    public String getHONBHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.HONBHYOJIEN);
    }

    /**
     * �{���\�����i�p���j��ݒ肷��
     *
     * @param val �{���\�����i�p���j
     */
    public void setHONBHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.HONBHYOJIEN, val);
    }

    /**
     * �g�D�R�[�h�i�ǁj���擾����
     *
     * @return �g�D�R�[�h�i�ǁj
     */
    public String getSIKCDKYK() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDKYK);
    }

    /**
     * �g�D�R�[�h�i�ǁj��ݒ肷��
     *
     * @param val �g�D�R�[�h�i�ǁj
     */
    public void setSIKCDKYK(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDKYK, val);
    }

    /**
     * �Ǖ\�����i�J�i�j���擾����
     *
     * @return �Ǖ\�����i�J�i�j
     */
    public String getKYKHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KYKHYOJIKN);
    }

    /**
     * �Ǖ\�����i�J�i�j��ݒ肷��
     *
     * @param val �Ǖ\�����i�J�i�j
     */
    public void setKYKHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.KYKHYOJIKN, val);
    }

    /**
     * �Ǖ\�����i�����j���擾����
     *
     * @return �Ǖ\�����i�����j
     */
    public String getKYKHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ);
    }

    /**
     * �Ǖ\�����i�����j��ݒ肷��
     *
     * @param val �Ǖ\�����i�����j
     */
    public void setKYKHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ, val);
    }

    /**
     * �Ǖ\�����̂��擾����
     *
     * @return �Ǖ\������
     */
    public String getKYKHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KYKHYOJIRYAKU);
    }

    /**
     * �Ǖ\�����̂�ݒ肷��
     *
     * @param val �Ǖ\������
     */
    public void setKYKHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.KYKHYOJIRYAKU, val);
    }

    /**
     * �Ǖ\�����i�p���j���擾����
     *
     * @return �Ǖ\�����i�p���j
     */
    public String getKYKHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KYKHYOJIEN);
    }

    /**
     * �Ǖ\�����i�p���j��ݒ肷��
     *
     * @param val �Ǖ\�����i�p���j
     */
    public void setKYKHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.KYKHYOJIEN, val);
    }

    /**
     * �g�D�R�[�h�i���j���擾����
     *
     * @return �g�D�R�[�h�i���j
     */
    public String getSIKCDSITU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDSITU);
    }

    /**
     * �g�D�R�[�h�i���j��ݒ肷��
     *
     * @param val �g�D�R�[�h�i���j
     */
    public void setSIKCDSITU(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDSITU, val);
    }

    /**
     * ���\�����i�J�i�j���擾����
     *
     * @return ���\�����i�J�i�j
     */
    public String getSITUHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SITUHYOJIKN);
    }

    /**
     * ���\�����i�J�i�j��ݒ肷��
     *
     * @param val ���\�����i�J�i�j
     */
    public void setSITUHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.SITUHYOJIKN, val);
    }

    /**
     * ���\�����i�����j���擾����
     *
     * @return ���\�����i�����j
     */
    public String getSITUHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SITUHYOJIKJ);
    }

    /**
     * ���\�����i�����j��ݒ肷��
     *
     * @param val ���\�����i�����j
     */
    public void setSITUHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.SITUHYOJIKJ, val);
    }

    /**
     * ���\�����̂��擾����
     *
     * @return ���\������
     */
    public String getSITUHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SITUHYOJIRYAKU);
    }

    /**
     * ���\�����̂�ݒ肷��
     *
     * @param val ���\������
     */
    public void setSITUHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.SITUHYOJIRYAKU, val);
    }

    /**
     * ���\�����i�p���j���擾����
     *
     * @return ���\�����i�p���j
     */
    public String getSITUHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SITUHYOJIEN);
    }

    /**
     * ���\�����i�p���j��ݒ肷��
     *
     * @param val ���\�����i�p���j
     */
    public void setSITUHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.SITUHYOJIEN, val);
    }

    /**
     * �g�D�R�[�h�i���j���擾����
     *
     * @return �g�D�R�[�h�i���j
     */
    public String getSIKCDBU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDBU);
    }

    /**
     * �g�D�R�[�h�i���j��ݒ肷��
     *
     * @param val �g�D�R�[�h�i���j
     */
    public void setSIKCDBU(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDBU, val);
    }

    /**
     * ���\�����i�J�i�j���擾����
     *
     * @return ���\�����i�J�i�j
     */
    public String getBUHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BUHYOJIKN);
    }

    /**
     * ���\�����i�J�i�j��ݒ肷��
     *
     * @param val ���\�����i�J�i�j
     */
    public void setBUHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.BUHYOJIKN, val);
    }

    /**
     * ���\�����i�����j���擾����
     *
     * @return ���\�����i�����j
     */
    public String getBUHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BUHYOJIKJ);
    }

    /**
     * ���\�����i�����j��ݒ肷��
     *
     * @param val ���\�����i�����j
     */
    public void setBUHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.BUHYOJIKJ, val);
    }

    /**
     * ���\�����̂��擾����
     *
     * @return ���\������
     */
    public String getBUHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BUHYOJIRYAKU);
    }

    /**
     * ���\�����̂�ݒ肷��
     *
     * @param val ���\������
     */
    public void setBUHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.BUHYOJIRYAKU, val);
    }

    /**
     * ���\�����i�p���j���擾����
     *
     * @return ���\�����i�p���j
     */
    public String getBUHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BUHYOJIEN);
    }

    /**
     * ���\�����i�p���j��ݒ肷��
     *
     * @param val ���\�����i�p���j
     */
    public void setBUHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.BUHYOJIEN, val);
    }

    /**
     * �g�D�R�[�h�i�ہj���擾����
     *
     * @return �g�D�R�[�h�i�ہj
     */
    public String getSIKCDKA() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDKA);
    }

    /**
     * �g�D�R�[�h�i�ہj��ݒ肷��
     *
     * @param val �g�D�R�[�h�i�ہj
     */
    public void setSIKCDKA(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDKA, val);
    }

    /**
     * �ە\�����i�J�i�j���擾����
     *
     * @return �ە\�����i�J�i�j
     */
    public String getKAHYOJIKN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KAHYOJIKN);
    }

    /**
     * �ە\�����i�J�i�j��ݒ肷��
     *
     * @param val �ە\�����i�J�i�j
     */
    public void setKAHYOJIKN(String val) {
        set(RepaVbjaMeu07SikKrSprd.KAHYOJIKN, val);
    }

    /**
     * �ە\�����i�����j���擾����
     *
     * @return �ە\�����i�����j
     */
    public String getKAHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KAHYOJIKJ);
    }

    /**
     * �ە\�����i�����j��ݒ肷��
     *
     * @param val �ە\�����i�����j
     */
    public void setKAHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.KAHYOJIKJ, val);
    }

    /**
     * �ە\�����̂��擾����
     *
     * @return �ە\������
     */
    public String getKAHYOJIRYAKU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KAHYOJIRYAKU);
    }

    /**
     * �ە\�����̂�ݒ肷��
     *
     * @param val �ە\������
     */
    public void setKAHYOJIRYAKU(String val) {
        set(RepaVbjaMeu07SikKrSprd.KAHYOJIRYAKU, val);
    }

    /**
     * �ە\�����i�p���j���擾����
     *
     * @return �ە\�����i�p���j
     */
    public String getKAHYOJIEN() {
        return (String) get(RepaVbjaMeu07SikKrSprd.KAHYOJIEN);
    }

    /**
     * �ە\�����i�p���j��ݒ肷��
     *
     * @param val �ە\�����i�p���j
     */
    public void setKAHYOJIEN(String val) {
        set(RepaVbjaMeu07SikKrSprd.KAHYOJIEN, val);
    }

}
