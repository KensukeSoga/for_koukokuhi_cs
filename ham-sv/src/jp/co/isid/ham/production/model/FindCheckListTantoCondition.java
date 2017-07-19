package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR�����@�������s���̃f�[�^�擾�����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/05 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindCheckListTantoCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���Ӑ�R�[�h */
    private String[] _tokuisakiCdList = null;

    /** ����From */
    private Date _fromDate = null;

    /** ����To */
    private Date _toDate = null;

    /** �����ǃR�[�h */
    private String[] _kyokuCdList = null;

    /**
     * �c�Ə��R�[�h
     */
    private String _egsCd = null;

    /** �c�Ɠ� */
    private String _eigyobi = null;

    /**
     * ���Ӑ�R�[�h���擾����
     *
     * @return ���Ӑ�R�[�h
     */
    @XmlElement(required = true)
    public String[] getTokuisakiCdList() {
        return _tokuisakiCdList;
    }

    /**
     * ���Ӑ�R�[�h��ݒ肷��
     *
     * @param tokuisakiCd ���Ӑ�R�[�h
     */
    public void setTokuisakiCdList(String[] tokuisakiCdList) {
        this._tokuisakiCdList = tokuisakiCdList;
    }

    /**
     * ����From���擾����
     *
     * @return ����From
     */
    @XmlElement(required = true)
    public Date getFromDate() {
        return _fromDate;
    }

    /**
     * ����From��ݒ肷��
     *
     * @param fromDate ����From
     */
    public void setFromDate(Date fromDate) {
        this._fromDate = fromDate;
    }

    /**
     * ����To���擾����
     *
     * @return ����To
     */
    @XmlElement(required = true)
    public Date getToDate() {
        return _toDate;
    }

    /**
     * ����To��ݒ肷��
     *
     * @param toDate ����To
     */
    public void setToDate(Date toDate) {
        this._toDate = toDate;
    }

    /**
     * �����ǃR�[�h���擾����
     *
     * @return �����ǃR�[�h
     */
    @XmlElement(required = true)
    public String[] getKyokuCdList() {
        return _kyokuCdList;
    }

    /**
     * �����ǃR�[�h��ݒ肷��
     *
     * @param kyokuCdList �����ǃR�[�h
     */
    public void setKyokuCdList(String[] kyokuCdList) {
        this._kyokuCdList = kyokuCdList;
    }

    /**
     * �c�Ə��R�[�h���擾����
     *
     * @return _egsCd
     */
    public String getEgsCd() {
        return _egsCd;
    }

    /**
     * �c�Ə��R�[�h��ݒ肷��
     * @param egsCd _egsCd
     */
    public void setEgsCd(String egsCd) {
        _egsCd = egsCd;
    }

    /**
     * �c�Ɠ����擾����
     *
     * @return �c�Ɠ�
     */
    public String getEigyobi() {
        return _eigyobi;
    }

    /**
     * �c�Ɠ���ݒ肷��
     *
     * @param eigyobi �c�Ɠ�
     */
    public void setEigyobi(String eigyobi) {
        _eigyobi = eigyobi;
    }
}
