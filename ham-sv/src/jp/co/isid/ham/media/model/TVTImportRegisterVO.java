package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;

public class TVTImportRegisterVO implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �o�^�pVO */
    private List<Tbj02EigyoDaichoVO> _insVo;

    /** �f�[�^�J�E���g*/
    private int _dataCount;

    /** �S���R�[�h���̍X�V�����̍ŐV�l*/
    private Date _latestDate;

    /** �S���R�[�h���̍ŐV�X�V��*/
    private String _latestID;

    /** ���ԊJ�n */
    private String _kikanFrom;

    /** ���ԏI�� */
    private String _kikanTo;

    /** �S����ID */
    private String _hamid = null;

    /** �_�~�[�v���p�e�B */
    private String _dummy;

    /**
     * @return insVo
     */
    public List<Tbj02EigyoDaichoVO> getInsVo() {
        return _insVo;
    }
    /**
     * @param insVo �Z�b�g���� insVo
     */
    public void setInsVo(List<Tbj02EigyoDaichoVO> insVo) {
        this._insVo = insVo;
    }

    /**
     * @return dataCount
     */
    public int getDataCount() {
        return _dataCount;
    }
    /**
     * @param dataCount �Z�b�g���� dataCount
     */
    public void setDataCount(int dataCount) {
        this._dataCount = dataCount;
    }

    /**
     * _latestDate
     *
     * @return _latestDate
     */
    @XmlElement(required = true)
    public Date getLatestDate() {
        return _latestDate;
    }

    /**
     * _latestDate
     *
     * @param _latestDate �f�[�^�X�V����
     */
    public void setLatestDate(Date latestDate) {
        this._latestDate = latestDate;
    }


    /**
     * @return latestID
     */
    public String getLatestID() {
        return _latestID;
    }
    /**
     * @param latestID �Z�b�g���� latestID
     */
    public void setLatestID(String latestID) {
        this._latestID = latestID;
    }

    /**
     * @return kikanFrom
     */
    public String getKikanFrom() {
        return _kikanFrom;
    }
    /**
     * @param kikanFrom �Z�b�g���� kikanFrom
     */
    public void setKikanFrom(String kikanFrom) {
        this._kikanFrom = kikanFrom;
    }

    /**
     * @return kikanTo
     */
    public String getKikanTo() {
        return _kikanTo;
    }
    /**
     * @param kikanTo �Z�b�g���� kikanTo
     */
    public void setKikanTo(String kikanTo) {
        this._kikanTo = kikanTo;
    }

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param hamid �S����ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * �_�~�[�v���p�e�B��Ԃ��܂�
     * @return
     */
    public String get_dummy() {
        return _dummy;
    }

    /**
     * �_�~�[�v���p�e�B��ݒ肷��
     * @param
     */
    public void set_dummy(String dummy) {
        _dummy = dummy;
    }
}
