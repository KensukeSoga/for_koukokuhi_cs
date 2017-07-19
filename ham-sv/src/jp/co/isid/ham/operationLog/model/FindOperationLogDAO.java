package jp.co.isid.ham.operationLog.model;

import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj28WorkLog;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 *
 * <P>
 * �ғ����O�擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/05/15 T.Kobayashi)<BR>
 * </P>
 *
 * @author T.Kobayashi
 */
public class FindOperationLogDAO extends AbstractRdbDao {

    /** �f�[�^�������� */
    private FindOperationLogCondition _cond = null;
    /** �t���OON */
    private static final String FLG_ON = "1";
    /** �g�D�����p������ */
    private static final String COMBINE_SOSHIKI = " || ' ' || ";

    /** �Ώۊ��ԃC���f�b�N�X */
    private static final int IDX_CRTDATE = 0;
    /** ESQID�C���f�b�N�X */
    private static final int IDX_HAMID = 1;
    /** �S���Җ��C���f�b�N�X */
    private static final int IDX_HAMNM = 2;
    /** �g�D���C���f�b�N�X */
    private static final int IDX_SOSHIKI_FULLNM = 3;
    /** ��ʖ��C���f�b�N�X */
    private static final int IDX_FORMNM = 4;
    /** �@�\���C���f�b�N�X */
    private static final int IDX_KNONM = 5;
    /** ���얼�C���f�b�N�X */
    private static final int IDX_DSMNM = 6;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindOperationLogDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[��Ԃ��܂�
     *
     * @return String[] �v���C�}���L�[
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    @Override
    public String[] getTableColumnNames() {

        String[] retTbl = new String[]{};

        if (_cond.getTotalFlg().indexOf(FLG_ON) == -1) {
            // �W�v�t���O���ݒ肳��Ă��Ȃ��ꍇ

            retTbl = new String[]{
                    Tbj28WorkLog.CRTDATE,
                    Tbj28WorkLog.HAMID,
                    Tbj28WorkLog.HAMNM,
                    Tbj28WorkLog.SIKCDHONB,
                    Tbj28WorkLog.SIKNMHONB,
                    Tbj28WorkLog.SIKCDKYK,
                    Tbj28WorkLog.SIKNMKYK,
                    Tbj28WorkLog.SIKCDSITU,
                    Tbj28WorkLog.SIKNMSITU,
                    Tbj28WorkLog.SIKCDBU,
                    Tbj28WorkLog.SIKNMBU,
                    Tbj28WorkLog.SIKCDKA,
                    Tbj28WorkLog.SIKNMKA,
                    Tbj28WorkLog.FORMID,
                    Tbj28WorkLog.FORMNM,
                    Tbj28WorkLog.KNOID,
                    Tbj28WorkLog.KNONM,
                    Tbj28WorkLog.DSMID,
                    Tbj28WorkLog.DSMNM,
                    Tbj28WorkLog.SIKNMKYK + COMBINE_SOSHIKI +
                    Tbj28WorkLog.SIKNMSITU + COMBINE_SOSHIKI +
                    Tbj28WorkLog.SIKNMBU + COMBINE_SOSHIKI +
                    Tbj28WorkLog.SIKNMKA + COMBINE_SOSHIKI + " '' AS SOSHIKI_FULLNM",
                    "1 AS LOG_COUNT"
            };
        } else {
            // �W�v�t���O���ݒ肳��Ă���ꍇ

            String[] flgList = _cond.getTotalFlg().split(",");
            ArrayList<String> tblList = new ArrayList<String>();

            for (int i = 0; i < flgList.length; i++) {
                if (flgList[i].equals(FLG_ON)) {
                    if (i == IDX_CRTDATE) {
                        // �Ώۊ���
                        tblList.add("TO_CHAR(" + Tbj28WorkLog.CRTDATE + ", 'YYYY/MM/DD') AS " + Tbj28WorkLog.CRTDATE);
                    } else if (i == IDX_HAMID) {
                        // ESQID
                        tblList.add(Tbj28WorkLog.HAMID);
                    } else if (i == IDX_HAMNM) {
                        // �S���Җ�
                        tblList.add(Tbj28WorkLog.HAMNM);
                    } else if (i == IDX_SOSHIKI_FULLNM) {
                        // �g�D��
                        tblList.add(
                                Tbj28WorkLog.SIKNMKYK + COMBINE_SOSHIKI +
                                Tbj28WorkLog.SIKNMSITU + COMBINE_SOSHIKI +
                                Tbj28WorkLog.SIKNMBU + COMBINE_SOSHIKI +
                                Tbj28WorkLog.SIKNMKA + " AS SOSHIKI_FULLNM"
                                );
                    } else if (i == IDX_FORMNM) {
                        // ��ʖ�
                        tblList.add(Tbj28WorkLog.FORMNM);
                    } else if (i == IDX_KNONM) {
                        // �@�\��
                        tblList.add(Tbj28WorkLog.KNONM);
                    } else if (i == IDX_DSMNM) {
                        // ���얼
                        tblList.add(Tbj28WorkLog.DSMNM);
                    }
                }
            }
            tblList.add(" COUNT(*) AS LOG_COUNT ");

            retTbl = (String[])tblList.toArray(new String[0]);
        }

        return retTbl;
    }

    /**
     * �e�[�u������Ԃ��܂�
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {

        StringBuffer tbl = new StringBuffer();

        tbl.append(Tbj28WorkLog.TBNAME);

        return tbl.toString();
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return getFindOperationLogDAO();
    }

    /**
     * �ғ����O��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getFindOperationLogDAO()
    {
        StringBuffer sql = new StringBuffer();
        boolean andFlg = false;

        sql.append("SELECT ");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length - 1) {
                sql.append(", ");
            }
        }

        sql.append(" FROM ");
        sql.append(getTableName());

        sql.append(" WHERE ");

        if (!(_cond.getCrtDateFrom().isEmpty())) {
            // �Ώۊ���(FROM)
            sql.append("TO_CHAR(" + Tbj28WorkLog.CRTDATE + ", 'YYYYMMDD') >= " + _cond.getCrtDateFrom() + " ");
            andFlg = true;
        }

        if (!(_cond.getCrtDateTo().isEmpty())) {
            // �Ώۊ���(TO)
            if (andFlg) {
                sql.append(" AND ");
            }
            sql.append("TO_CHAR(" + Tbj28WorkLog.CRTDATE + ", 'YYYYMMDD') <= " + _cond.getCrtDateTo() + " ");
        }

        if (!(_cond.getHamId().isEmpty())) {
            // ESQID
            sql.append(" AND " + Tbj28WorkLog.HAMID + " LIKE '%" + _cond.getHamId() + "%'");
        }

        if (!(_cond.getHamNm().isEmpty())) {
            // �S���Җ�
            sql.append(" AND " + Tbj28WorkLog.HAMNM + " LIKE '%" + _cond.getHamNm() + "%'");
        }

        if (!(_cond.getSikNmKyk().isEmpty())) {
            // �g�D��
//            sql.append(" AND ( " + Tbj28WorkLog.SIKNMKYK + " LIKE '%" + _cond.getSikNmKyk() + "%'");
//            sql.append(" OR " + Tbj28WorkLog.SIKNMSITU + " LIKE '%" + _cond.getSikNmKyk() + "%'");
//            sql.append(" OR " + Tbj28WorkLog.SIKNMBU + " LIKE '%" + _cond.getSikNmKyk() + "%'");
//            sql.append(" OR " + Tbj28WorkLog.SIKNMKA + " LIKE '%" + _cond.getSikNmKyk() + "%' ) ");
            sql.append(" AND ");
            sql.append(Tbj28WorkLog.SIKNMKYK);
            sql.append(COMBINE_SOSHIKI);
            sql.append(Tbj28WorkLog.SIKNMSITU);
            sql.append(COMBINE_SOSHIKI);
            sql.append(Tbj28WorkLog.SIKNMBU);
            sql.append(COMBINE_SOSHIKI);
            sql.append(Tbj28WorkLog.SIKNMKA);
            sql.append(" LIKE '%").append(_cond.getSikNmKyk()).append("%'");
        }

        if (!(_cond.getFormNm().isEmpty())) {
            // ��ʖ�
            sql.append(" AND " + Tbj28WorkLog.FORMNM + " LIKE '%" + _cond.getFormNm() + "%'");
        }

        if (!(_cond.getKnoNm().isEmpty())) {
            // �@�\��
            sql.append(" AND " + Tbj28WorkLog.KNONM + " LIKE '%" + _cond.getKnoNm() + "%'");
        }

        if (!(_cond.getDsmNm().isEmpty())) {
            // ���얼
            sql.append(" AND " + Tbj28WorkLog.DSMNM + " LIKE '%" + _cond.getDsmNm() + "%'");
        }

        if (_cond.getTotalFlg().indexOf(FLG_ON) == -1) {
            // �W�v�t���O���ݒ肳��Ă��Ȃ��ꍇ

            // �f�[�^�쐬�����Ń\�[�g
            sql.append(" ORDER BY ");
            sql.append(Tbj28WorkLog.CRTDATE);

        } else {
            // �W�v�t���O���ݒ肳��Ă���ꍇ

            /** GROUP BY �ݒ� **/

            sql.append(" GROUP BY ");

            String[] flgList = _cond.getTotalFlg().split(",");

            for (int i = 0; i < flgList.length; i++) {
                if (flgList[i].equals(FLG_ON)) {
                    if (i == IDX_CRTDATE) {
                        // �Ώۊ���
                        sql.append("TO_CHAR(" + Tbj28WorkLog.CRTDATE + ", 'YYYY/MM/DD')" + ",");
                    } else if (i == IDX_HAMID) {
                        // ESQID
                        sql.append(Tbj28WorkLog.HAMID + ",");
                    } else if (i == IDX_HAMNM) {
                        // �S���Җ�
                        sql.append(Tbj28WorkLog.HAMNM + ",");
                    } else if (i == IDX_SOSHIKI_FULLNM) {
                        // �g�D��
                        sql.append(Tbj28WorkLog.SIKNMKYK + ",");
                        sql.append(Tbj28WorkLog.SIKNMSITU + ",");
                        sql.append(Tbj28WorkLog.SIKNMBU + ",");
                        sql.append(Tbj28WorkLog.SIKNMKA + ",");

                    } else if (i == IDX_FORMNM) {
                        // ��ʖ�
                        sql.append(Tbj28WorkLog.FORMNM + ",");
                    } else if (i == IDX_KNONM) {
                        // �@�\��
                        sql.append(Tbj28WorkLog.KNONM + ",");
                    } else if (i == IDX_DSMNM) {
                        // ���얼
                        sql.append(Tbj28WorkLog.DSMNM + ",");
                    }
                }
            }
            // �Ō��,���폜
            sql.deleteCharAt(sql.length() - 1);

            /** ORDER BY �ݒ� **/

            // �f�[�^�쐬�����Ń\�[�g
            sql.append(" ORDER BY ");

            for (int i = 0; i < flgList.length; i++) {
                if (flgList[i].equals(FLG_ON)) {
                    if (i == IDX_CRTDATE) {
                        // �Ώۊ���
                        sql.append(Tbj28WorkLog.CRTDATE + ",");
                    } else if (i == IDX_HAMID) {
                        // ESQID
                        sql.append(Tbj28WorkLog.HAMID + ",");
                    } else if (i == IDX_HAMNM) {
                        // �S���Җ�
                        sql.append(Tbj28WorkLog.HAMNM + ",");
                    } else if (i == IDX_SOSHIKI_FULLNM) {
                        // �g�D��
                        sql.append(Tbj28WorkLog.SIKNMKYK + ",");
                        sql.append(Tbj28WorkLog.SIKNMSITU + ",");
                        sql.append(Tbj28WorkLog.SIKNMBU + ",");
                        sql.append(Tbj28WorkLog.SIKNMKA + ",");

                    } else if (i == IDX_FORMNM) {
                        // ��ʖ�
                        sql.append(Tbj28WorkLog.FORMNM + ",");
                    } else if (i == IDX_KNONM) {
                        // �@�\��
                        sql.append(Tbj28WorkLog.KNONM + ",");
                    } else if (i == IDX_DSMNM) {
                        // ���얼
                        sql.append(Tbj28WorkLog.DSMNM + ",");
                    }
                   }
            }
            // �Ō��,���폜
            sql.deleteCharAt(sql.length() - 1);

        }

        return sql.toString();
    }

    /**
     * �ғ����O�̌������s���܂�
     *
     * @return �ғ����OVO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindOperationLogVO> selectVO(FindOperationLogCondition cond) throws HAMException {

        List<FindOperationLogVO> result = null;

        //�p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new FindOperationLogVO());

        try {
            _cond = cond;
            result = super.find();
            return result;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
