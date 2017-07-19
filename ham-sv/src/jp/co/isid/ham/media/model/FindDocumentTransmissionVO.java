package jp.co.isid.ham.media.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���e�\(���)VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/09/20 Fujiyoshi)<BR>
 * </P>
 * @author Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class FindDocumentTransmissionVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;


    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj02EigyoDaicho.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj02EigyoDaicho.DCARCD, val);
    }

    /**
     * �Ԏ햼���擾����
     *
     * @return �Ԏ햼
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * �Ԏ햼��ݒ肷��
     *
     * @param val �Ԏ햼
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * �L�����y�[�������擾����
     *
     * @return �L�����y�[����
     */
    public String getCAMPAIGN() {
        return (String) get(Tbj02EigyoDaicho.CAMPAIGN);
    }

    /**
     * �L�����y�[������ݒ肷��
     *
     * @param val �L�����y�[����
     */
    public void setCAMPAIGN(String val) {
        set(Tbj02EigyoDaicho.CAMPAIGN, val);
    }

    /**
     * ���ԊJ�n(�L�����y�[��)���擾����
     *
     * @return ���ԊJ�n(�L�����y�[��)
     */
    @XmlElement(required = true, nillable = true)
    public Date getTERMSTART() {
        return (Date) get("TERMSTART");
    }

    /**
     * ���ԊJ�n(�L�����y�[��)��ݒ肷��
     *
     * @param val ���ԊJ�n(�L�����y�[��)
     */
    public void setTERMSTART(Date val) {
        set("TERMSTART", val);
    }

    /**
     * ���ԏI��(�L�����y�[��)���擾����
     *
     * @return ���ԏI��(�L�����y�[��)
     */
    @XmlElement(required = true, nillable = true)
    public Date getTERMEND() {
        return (Date) get("TERMEND");
    }

    /**
     * ���ԏI��(�L�����y�[��)��ݒ肷��
     *
     * @param val ���ԏI��(�L�����y�[��)
     */
    public void setTERMEND(Date val) {
        set("TERMEND", val);
    }
}
