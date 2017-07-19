package jp.co.isid.ham.production.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �^�����g�E�i���[�^�[�E�y�Ȍ_��\����(���[�p)�f�[�^�ێ��N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/03/26 T.Hadate)<BR>
 * </P>
 *
 * @author Takahiro Hadate
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class Contract4ReportVO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = -5319490262128457569L;

    /** ���ԊJ�n�̍ŏ��l */
    private static final String MIN_DATEFROM = "MIN_DATEFROM";


    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Contract4ReportVO() {
    }

    /**
     * �Ԏ�R�[�h���擾����.
     *
     * @return �Ԏ�R�[�h
     */
    public String getDcarcd()     {
        Object obj = get(Tbj18SozaiKanriData.DCARCD);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��.
     *
     * @param val �Ԏ�R�[�h
     */
    public void setDcarcd(String val) {
        set(Tbj18SozaiKanriData.DCARCD, val);
    }

    /**
     * �Ԏ햼���擾����.
     *
     * @return �Ԏ햼
     */
    public String getCarnm() {
        Object obj = get(Mbj05Car.CARNM);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * �Ԏ햼��ݒ肷��.
     *
     * @param val �Ԏ햼
     */
    public void setCarnm(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * �^�C�g�����擾����.
     *
     * @return �^�C�g��
     */
    public String getTitle() {
        Object obj = get(Tbj18SozaiKanriData.TITLE);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * �^�C�g����ݒ肷��.
     *
     * @param val �^�C�g��
     */
    public void setTitle(String val) {
        set(Tbj18SozaiKanriData.TITLE, val);
    }

    /**
     * ���ԊJ�n�̍ŏ��l���擾����.
     *
     * @return ���ԊJ�n�̍ŏ��l
     */
    public Date getMinDateFrom() {
        Object obj = get(MIN_DATEFROM);
        return (obj != null) ? (Date) obj : null;
    }

    /**
     * ���ԊJ�n�̍ŏ��l��ݒ肷��.
     *
     * @param val ���ԊJ�n�̍ŏ��l
     */
    public void setMinDateFrom(Date val) {
        set(MIN_DATEFROM, val);
    }

    /**
     * �_���ނ��擾����.
     *
     * @return �_����
     */
    public String getCtrtkbn() {
        Object obj = get(Tbj16ContractInfo.CTRTKBN);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * �_���ނ�ݒ肷��.
     *
     * @param val �_����
     */
    public void setCtrtkbn(String val) {
        set(Tbj16ContractInfo.CTRTKBN, val);
    }

    /**
     * ���̂��擾����.
     *
     * @return ����
     */
    public String getNames() {
        Object obj = get(Tbj16ContractInfo.NAMES);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * ���̂�ݒ肷��.
     *
     * @param val ����
     */
    public void setNames(String val) {
        set(Tbj16ContractInfo.NAMES, val);
    }

    /**
     * �y�Ȗ����擾����.
     *
     * @return �y�Ȗ�
     */
    public String getMusic() {
        Object obj = get(Tbj16ContractInfo.MUSIC);
        return (obj != null) ? obj.toString() : null;
    }

    /**
     * �y�Ȗ���ݒ肷��.
     *
     * @param val �y�Ȗ�
     */
    public void setMusic(String val) {
        set(Tbj16ContractInfo.MUSIC, val);
    }

    /**
     * �_�����(From)���擾����.
     *
     * @return �_�����(From)
     */
    public Date getDateFrom() {
        Object obj = get(Tbj16ContractInfo.DATEFROM);
        return (obj != null) ? (Date) obj : null;
    }

    /**
     * �_�����(From)��ݒ肷��.
     *
     * @param val �_�����(From)
     */
    public void setDateFrom(Date val) {
        set(Tbj16ContractInfo.DATEFROM, val);
    }

    /**
     * �_�����(To)���擾����.
     *
     * @return �_�����(To)
     */
    public Date getDateTo() {
        Object obj = get(Tbj16ContractInfo.DATETO);
        return (obj != null) ? (Date) obj : null;
    }

    /**
     * �_�����(To)��ݒ肷��.
     *
     * @param val �_�����(To)
     */
    public void setDateTo(Date val) {
        set(Tbj16ContractInfo.DATETO, val);
    }
}
