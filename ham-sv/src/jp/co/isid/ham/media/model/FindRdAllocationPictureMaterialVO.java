package jp.co.isid.ham.media.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���W�I��AllocationPicture�f�ޏ�񌟍�VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/12/10 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdAllocationPictureMaterialVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** SEQ */
    public static final String SEQ = "SEQ";

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindRdAllocationPictureMaterialVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindRdAllocationPictureMaterialVO();
    }

    /**
     * SEQ���擾����
     * @return BigDecimal SEQ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQ() {
        return (BigDecimal) get(SEQ);
    }

    /**
     * SEQ��ݒ肷��
     * @param val BigDecimal SEQ
     */
    public void setSEQ(BigDecimal val) {
        set(SEQ, val);
    }

    /**
     * 10��CM�R�[�h���擾����
     * @return String 10��CM�R�[�h
     */
    public String getCMCD() {
        return (String) get(Tbj20SozaiKanriList.CMCD);
    }

    /**
     * 10��CM�R�[�h��ݒ肷��
     * @param val String 10��CM�R�[�h
     */
    public void setCMCD(String val) {
        set(Tbj20SozaiKanriList.CMCD, val);
    }

    /**
     * ���R�[�h���擾����
     * @return String ���R�[�h
     */
    public String getRCODE() {
        return (String) get(Tbj20SozaiKanriList.RCODE);
    }

    /**
     * ���R�[�h��ݒ肷��
     * @param val String ���R�[�h
     */
    public void setRCODE(String val) {
        set(Tbj20SozaiKanriList.RCODE, val);
    }

    /**
     * �^�C�g�����擾����
     * @return String �^�C�g��
     */
    public String getTITLE() {
        return (String) get(Tbj20SozaiKanriList.TITLE);
    }

    /**
     * �^�C�g����ݒ肷��
     * @param val String �^�C�g��
     */
    public void setTITLE(String val) {
        set(Tbj20SozaiKanriList.TITLE, val);
    }

    /**
     * �Ԏ�R�[�h���擾����
     * @return String �Ԏ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj20SozaiKanriList.DCARCD);
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     * @param val String �Ԏ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj20SozaiKanriList.DCARCD, val);
    }

    /**
     * �Ԏ햼���擾����
     * @return String �Ԏ햼
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * �Ԏ햼��ݒ肷��
     * @param val String �Ԏ햼
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * �b�����擾����
     * @return String �b��
     */
    public String getSecond() {
        return (String) get(Tbj20SozaiKanriList.SECOND);
    }

    /**
     * �b����ݒ肷��
     * @param val String �b��
     */
    public void setSecond(String val) {
        set(Tbj20SozaiKanriList.SECOND, val);
    }

    /**
     * �����F���擾����
     * @return String �����F
     */
    public String getFORECOLOR() {
        return (String) get(Tbj20SozaiKanriList.FORECOLOR);
    }

    /**
     * �����F��ݒ肷��
     * @param val String �����F
     */
    public void setFORECOLOR(String val) {
        set(Tbj20SozaiKanriList.FORECOLOR, val);
    }

    /**
     * �w�i�F���擾����
     * @return String �w�i�F
     */
    public String getBACKCOLOR() {
        return (String) get(Tbj20SozaiKanriList.BACKCOLOR);
    }

    /**
     * �w�i�F��ݒ肷��
     * @param val String �w�i�F
     */
    public void setBACKCOLOR(String val) {
        set(Tbj20SozaiKanriList.BACKCOLOR, val);
    }

}
