package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.common.model.Tbj12CampaignVO;

public class CampaignRegisterCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �폜�pVO */
    private List<Tbj12CampaignVO> _delVo;

    /** �X�V�pVO */
    private List<Tbj12CampaignVO> _updVo;

    /**�o�^�pVO */
    private List<Tbj12CampaignVO> _insVo;

    /**�f�[�^�J�E���g*/
    private int _dataCount;

    /**�S���R�[�h���̍X�V�����̍ŐV�l*/
    private Date _latestDate;

    /**�S���R�[�h���̍ŐV�X�V��*/
    private String _latestPel;

    /** �_�~�[�v���p�e�B */
    private String _dummy;


    /**
     * @return delVo
     */
    public List<Tbj12CampaignVO> getDelVo() {
        return _delVo;
    }
    /**
     * @param delVo �Z�b�g���� delVo
     */
    public void setDelVo(List<Tbj12CampaignVO> delVo) {
        this._delVo = delVo;
    }

    /**
     * @return updVo
     */
    public List<Tbj12CampaignVO> getUpdVo() {
        return _updVo;
    }
    /**
     * @param updVo �Z�b�g���� updVo
     */
    public void setUpdVo(List<Tbj12CampaignVO> updVo) {
        this._updVo = updVo;
    }

    /**
     * @return insVo
     */
    public List<Tbj12CampaignVO> getInsVo() {
        return _insVo;
    }
    /**
     * @param insVo �Z�b�g���� insVo
     */
    public void setInsVo(List<Tbj12CampaignVO> insVo) {
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
     * @return latestPel
     */
    public String getLatestPel() {
        return _latestPel;
    }
    /**
     * @param latestPel �Z�b�g���� latestPel
     */
    public void setLatestPel(String latestPel) {
        this._latestPel = latestPel;
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